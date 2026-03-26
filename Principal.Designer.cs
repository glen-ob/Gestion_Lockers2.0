// Compatibilidad con nombres antiguos --- añadir dentro de la clase partial Principal
// (colócalo después de las declaraciones de campos)
private System.Windows.Forms.TextBox textBox1 { get => this.TXTNombre; }
private System.Windows.Forms.TextBox textBox2 { get => this.txtTelefono; }
private System.Windows.Forms.TextBox textBox3 { get => this.txtMatricula; }
private System.Windows.Forms.Button btnagregar { get => this.btnAsignar; }