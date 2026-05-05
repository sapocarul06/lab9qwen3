namespace ProductsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Text = "Gestiune Produse";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView
            _dataGridView = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                MultiSelect = false
            };
            _dataGridView.CellClick += DataGridView_CellClick;
            this.Controls.Add(_dataGridView);

            // Labels and TextBoxes
            var lblName = new Label { Text = "Nume:", Location = new System.Drawing.Point(20, 290), Size = new System.Drawing.Size(100, 25) };
            this.Controls.Add(lblName);

            _txtName = new TextBox { Location = new System.Drawing.Point(130, 290), Size = new System.Drawing.Size(200, 25) };
            this.Controls.Add(_txtName);

            var lblPrice = new Label { Text = "Preț:", Location = new System.Drawing.Point(350, 290), Size = new System.Drawing.Size(100, 25) };
            this.Controls.Add(lblPrice);

            _txtPrice = new TextBox { Location = new System.Drawing.Point(460, 290), Size = new System.Drawing.Size(150, 25) };
            this.Controls.Add(_txtPrice);

            var lblQuantity = new Label { Text = "Cantitate:", Location = new System.Drawing.Point(630, 290), Size = new System.Drawing.Size(80, 25) };
            this.Controls.Add(lblQuantity);

            _txtQuantity = new TextBox { Location = new System.Drawing.Point(710, 290), Size = new System.Drawing.Size(50, 25) };
            this.Controls.Add(_txtQuantity);

            // Buttons
            _btnAdd = new Button { Text = "Adaugă", Location = new System.Drawing.Point(20, 340), Size = new System.Drawing.Size(100, 35) };
            _btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(_btnAdd);

            _btnEdit = new Button { Text = "Editează", Location = new System.Drawing.Point(140, 340), Size = new System.Drawing.Size(100, 35) };
            _btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(_btnEdit);

            _btnDelete = new Button { Text = "Șterge", Location = new System.Drawing.Point(260, 340), Size = new System.Drawing.Size(100, 35) };
            _btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(_btnDelete);

            _btnRefresh = new Button { Text = "Reîmprospătează", Location = new System.Drawing.Point(380, 340), Size = new System.Drawing.Size(120, 35) };
            _btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(_btnRefresh);
        }

        #endregion
    }
}
