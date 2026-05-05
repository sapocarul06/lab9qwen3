using System;
using System.Windows.Forms;

namespace ProductsApp
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private DataGridView _dataGridView;
        private TextBox _txtName;
        private TextBox _txtPrice;
        private TextBox _txtQuantity;
        private Button _btnAdd;
        private Button _btnEdit;
        private Button _btnDelete;
        private Button _btnRefresh;
        private int _selectedProductId = -1;

        public MainForm(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
            InitializeComponent();
            LoadProducts();
        }

        private void InitializeComponent()
        {
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

        private void LoadProducts()
        {
            try
            {
                var products = _dbHelper.GetAllProducts();
                _dataGridView.DataSource = null;
                _dataGridView.DataSource = products;
                
                // Configure columns
                _dataGridView.Columns["Id"].HeaderText = "ID";
                _dataGridView.Columns["Name"].HeaderText = "Nume";
                _dataGridView.Columns["Price"].HeaderText = "Preț";
                _dataGridView.Columns["Quantity"].HeaderText = "Cantitate";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = _dataGridView.Rows[e.RowIndex];
                _selectedProductId = (int)row.Cells["Id"].Value;
                _txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                _txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "0";
                _txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "0";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_txtName.Text))
                {
                    MessageBox.Show("Numele produsului este obligatoriu!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(_txtPrice.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Prețul trebuie să fie un număr pozitiv!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(_txtQuantity.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Cantitatea trebuie să fie un număr pozitiv!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new Product
                {
                    Name = _txtName.Text.Trim(),
                    Price = price,
                    Quantity = quantity
                };

                _dbHelper.AddProduct(product);
                ClearFields();
                LoadProducts();
                MessageBox.Show("Produs adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProductId == -1)
                {
                    MessageBox.Show("Selectați un produs din tabel pentru editare!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(_txtName.Text))
                {
                    MessageBox.Show("Numele produsului este obligatoriu!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(_txtPrice.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Prețul trebuie să fie un număr pozitiv!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(_txtQuantity.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Cantitatea trebuie să fie un număr pozitiv!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new Product
                {
                    Id = _selectedProductId,
                    Name = _txtName.Text.Trim(),
                    Price = price,
                    Quantity = quantity
                };

                _dbHelper.UpdateProduct(product);
                ClearFields();
                LoadProducts();
                MessageBox.Show("Produs actualizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProductId == -1)
                {
                    MessageBox.Show("Selectați un produs din tabel pentru ștergere!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Sigur doriți să ștergeți produsul cu ID {_selectedProductId}?", 
                    "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dbHelper.DeleteProduct(_selectedProductId);
                    ClearFields();
                    LoadProducts();
                    MessageBox.Show("Produs șters cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea produsului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadProducts();
        }

        private void ClearFields()
        {
            _selectedProductId = -1;
            _txtName.Clear();
            _txtPrice.Clear();
            _txtQuantity.Clear();
            _dataGridView.ClearSelection();
        }
    }
}
