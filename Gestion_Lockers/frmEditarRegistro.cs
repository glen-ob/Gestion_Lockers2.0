using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class frmEditarRegistro : Form
    {
        private readonly string _tableName;
        private readonly DataRow _originalRow;
        private readonly DataTable _snapshotTable;
        private readonly Dictionary<string, TextBox> _editors = new();

        public frmEditarRegistro(string tableName, DataRow row, DataTable snapshot)
        {
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _originalRow = row ?? throw new ArgumentNullException(nameof(row));
            _snapshotTable = snapshot ?? throw new ArgumentNullException(nameof(snapshot));

            Text = "Editar registro";
            StartPosition = FormStartPosition.CenterParent;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new System.Drawing.Size(500, 200);
            Padding = new Padding(12);

            BuildUI(row);
        }

        private void BuildUI(DataRow row)
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true,
                Padding = new Padding(0, 0, 0, 8)
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));

            foreach (DataColumn col in row.Table.Columns)
            {
                var lbl = new Label
                {
                    Text = col.ColumnName,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Font = new System.Drawing.Font("Century Gothic", 11F)
                };
                var tb = new TextBox
                {
                    Text = row[col]?.ToString() ?? string.Empty,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Width = 300,
                    Font = new System.Drawing.Font("Century Gothic", 11F)
                };

                // Primera columna = clave primaria → solo lectura
                if (col.Ordinal == 0)
                {
                    tb.ReadOnly = true;
                    tb.BackColor = System.Drawing.SystemColors.Control;
                }

                panel.Controls.Add(lbl);
                panel.Controls.Add(tb);
                _editors[col.ColumnName] = tb;
            }

            var btnGuardar = new Button { Text = "Guardar", DialogResult = DialogResult.OK, Font = new System.Drawing.Font("Century Gothic", 11F), Size = new System.Drawing.Size(120, 36) };
            var btnCancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Font = new System.Drawing.Font("Century Gothic", 11F), Size = new System.Drawing.Size(120, 36) };

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(4)
            };
            flow.Controls.Add(btnGuardar);
            flow.Controls.Add(btnCancelar);

            Controls.Add(panel);
            Controls.Add(flow);

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, ev) => Close();
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string pkColumn = _snapshotTable.Columns[0].ColumnName;
            string pkValue = _editors[pkColumn].Text;

            // Sanear nombres de columna/tabla: solo letras, dígitos y _
            if (!EsNombreSeguro(_tableName))
            {
                MessageBox.Show("Nombre de tabla no válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var columns = new List<string>();
            foreach (DataColumn col in _snapshotTable.Columns)
                if (col.ColumnName != pkColumn && EsNombreSeguro(col.ColumnName))
                    columns.Add(col.ColumnName);

            if (columns.Count == 0)
            {
                MessageBox.Show("No hay columnas editables.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sb = new StringBuilder();
            sb.Append("UPDATE ").Append(_tableName).Append(" SET ");
            for (int i = 0; i < columns.Count; i++)
            {
                sb.Append(columns[i]).Append(" = @p").Append(i);
                if (i < columns.Count - 1) sb.Append(", ");
            }
            sb.Append(" WHERE ").Append(pkColumn).Append(" = @pk;");

            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(sb.ToString(), conn);

                for (int i = 0; i < columns.Count; i++)
                    cmd.Parameters.AddWithValue("@p" + i, _editors[columns[i]].Text);
                cmd.Parameters.AddWithValue("@pk", pkValue);

                int afectadas = cmd.ExecuteNonQuery();
                if (afectadas == 0)
                {
                    MessageBox.Show("No se actualizó ningún registro. Verifica la clave primaria.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("Registro actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        /// <summary>Solo permite nombres que contengan letras, dígitos o guión bajo.</summary>
        private static bool EsNombreSeguro(string name)
            => !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^\w+$");
    }
}