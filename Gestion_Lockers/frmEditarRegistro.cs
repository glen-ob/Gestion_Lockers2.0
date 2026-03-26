using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class frmEditarRegistro : Form
    {
        private readonly string tableName;
        private readonly DataRow originalRow;
        private readonly DataTable snapshotTable;
        private readonly TableLayoutPanel panel;
        private readonly Button btnGuardar;
        private readonly Button btnCancelar;

        // Guardamos pares (columnName -> TextBox)
        private readonly System.Collections.Generic.Dictionary<string, TextBox> editors = new();

        public frmEditarRegistro(string tableName, DataRow row, DataTable snapshot)
        {
            this.tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            this.originalRow = row ?? throw new ArgumentNullException(nameof(row));
            this.snapshotTable = snapshot ?? throw new ArgumentNullException(nameof(snapshot));

            Text = "Editar registro";
            Size = new Size(500, 60 + 30 * row.Table.Columns.Count + 80);
            StartPosition = FormStartPosition.CenterParent;

            panel = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, AutoSize = true };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            Controls.Add(panel);

            // Crear controles para cada columna
            foreach (DataColumn col in row.Table.Columns)
            {
                var lbl = new Label { Text = col.ColumnName, Anchor = AnchorStyles.Left, AutoSize = true };
                var tb = new TextBox { Text = row[col]?.ToString() ?? string.Empty, Anchor = AnchorStyles.Left | AnchorStyles.Right, Width = 300 };

                // Suponemos la primera columna como clave primaria y la marcamos read-only
                if (col == row.Table.Columns[0])
                    tb.ReadOnly = true;

                panel.Controls.Add(lbl);
                panel.Controls.Add(tb);
                editors[col.ColumnName] = tb;
            }

            btnGuardar = new Button { Text = "Guardar", DialogResult = DialogResult.OK, Anchor = AnchorStyles.Right };
            btnCancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Anchor = AnchorStyles.Left };

            var flow = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50, FlowDirection = FlowDirection.RightToLeft };
            flow.Controls.Add(btnGuardar);
            flow.Controls.Add(btnCancelar);
            Controls.Add(flow);

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.Close(); };
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            // Construir UPDATE dinámico: UPDATE tableName SET col1=@p1,... WHERE pk = @pk
            var pkColumn = snapshotTable.Columns[0].ColumnName;
            var pkValue = editors[pkColumn].Text;

            var sb = new StringBuilder();
            sb.Append("UPDATE ").Append(tableName).Append(" SET ");

            var columns = new System.Collections.Generic.List<string>();
            foreach (DataColumn col in snapshotTable.Columns)
            {
                if (col.ColumnName == pkColumn) continue;
                columns.Add(col.ColumnName);
            }

            for (int i = 0; i < columns.Count; i++)
            {
                sb.Append(columns[i]).Append(" = @p").Append(i);
                if (i < columns.Count - 1) sb.Append(", ");
            }

            sb.Append(" WHERE ").Append(pkColumn).Append(" = @pk;");

            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand(sb.ToString(), conn))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        string colName = columns[i];
                        cmd.Parameters.AddWithValue("@p" + i, editors[colName].Text);
                    }
                    cmd.Parameters.AddWithValue("@pk", pkValue);
                    int afectadas = cmd.ExecuteNonQuery();
                    if (afectadas == 0)
                    {
                        MessageBox.Show("No se actualizó ningún registro. Comprueba la clave primaria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}