using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Newtonsoft.Json;

namespace EMSWindForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var apiService = new ApiService();
                var json = await apiService.GetTradeEquipmentJsonAsync();

                var tradeEquipments = JsonConvert.DeserializeObject<List<TradeEquipment>>(json);

                dataGridView1.DataSource = tradeEquipments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEditForm addForm = new AddEditForm();
            addForm.ShowDialog();
            LoadData();
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);
                AddEditForm editForm = new AddEditForm(id);
                editForm.ShowDialog();

                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);
                try
                {
                    var apiService = new ApiService();
                    await apiService.DeleteTradeEquipmentAsync(id);
                    MessageBox.Show("Запись успешно удалена.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
