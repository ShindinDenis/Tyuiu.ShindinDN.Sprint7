using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.ShindinDN.Sprint7.Project.V7.Lib;

namespace Tyuiu.ShindinDN.Sprint7.Project.V7
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        static int rows;
        static int columns;
        string filepath;
        DataService ds = new DataService();

        public void FormMain_Load(object sender, EventArgs e)
        {

        }
        public static string[,] LoadFromFileData(string filePath)
        {
            string FileData = File.ReadAllText(filePath);

            FileData = FileData.Replace('\n', '\r');
            string[] lines = FileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            rows = lines.Length;
            columns = lines[0].Split(';').Length;

            string[,] arrayValues = new string[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < columns; c++)
                {
                    arrayValues[r, c] = line_r[c];
                }
            }
            return arrayValues;
        }

        private void buttonOpenBase_SDN_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogMain_SDN.ShowDialog();
                filepath = openFileDialogMain_SDN.FileName;

                string[,] arrayValues = new string[rows, columns];

                arrayValues = LoadFromFileData(filepath);

                arrayValues = ds.getfile(filepath);

                buttonViewBase_SDN.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_SDN_Click(object sender, EventArgs e)
        {
            saveFileDialog_SDN.FileName = "Base.csv";
            saveFileDialog_SDN.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog_SDN.ShowDialog();

            string path = saveFileDialog_SDN.FileName;

            FileInfo fileInfo = new FileInfo(path);
            bool FileExists = fileInfo.Exists;

            if (FileExists)
            {
                File.Delete(path);
            }

            int rows = dataGridViewBase_SDN.RowCount;
            int columns = dataGridViewBase_SDN.ColumnCount;

            string str = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j != columns - 1)
                    {
                        str = str + dataGridViewBase_SDN.Rows[i].Cells[j].Value + ";";
                    }
                    else
                    {
                        str = str + dataGridViewBase_SDN.Rows[i].Cells[j].Value;
                    }
                }
                File.AppendAllText(path, str + Environment.NewLine);
                str = "";
            }
        }

        private void buttonDelete_SDN_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBase_SDN.CurrentRow.Index >= 0)
                {
                    int a = dataGridViewBase_SDN.CurrentRow.Index;
                    dataGridViewBase_SDN.Rows.Remove(dataGridViewBase_SDN.Rows[a]);
                    if (dataGridViewBase_SDN.Rows.Count == 0)
                    {
                        dataGridViewBase_SDN.Rows.Clear();
                    }
                }
                if (dataGridViewBase_SDN.Rows.Count <= 1)
                {
                    buttonDelete_SDN.Enabled = false;
                    buttonSearch_SDN.Enabled = false;
                }
                if (dataGridViewBase_SDN.Rows.Count > 1)
                {
                    buttonDelete_SDN.Enabled = true;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при удалении записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonViewBase_SDN_Click(object sender, EventArgs e)
        {
            dataGridViewBase_SDN.ColumnCount = columns;
            dataGridViewBase_SDN.RowCount = rows;


            dataGridViewBase_SDN.Rows[0].ReadOnly = true;
            dataGridViewBase_SDN.Columns[0].ReadOnly = true;

            string[,] arrayValues = new string[rows, columns];
            arrayValues = LoadFromFileData(filepath);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewBase_SDN.Rows[r].Cells[c].Value = arrayValues[r, c];
                }
            }
            arrayValues = ds.getfile(filepath);

            buttonFiltCwi_SDN.Enabled = true;
            buttonSearch_SDN.Enabled = true;
            buttonDelete_SDN.Enabled = true;
            buttonSave_SDN.Enabled = true;
            buttonAdd_SDN.Enabled = true;
            buttonMin_SDN.Enabled = true;
            buttonAverage_SDN.Enabled = true;
            buttonMax_SDN.Enabled = true;
            buttonFiltCancel_SDN.Enabled = true;
            buttonFiltMoney_SDN.Enabled = true;
            textBoxSearch_SDN.Enabled = true;
            textBoxMax_SDN.Enabled = true;
            textBoxMin_SDN.Enabled = true;
            textBoxAverage_SDN.Enabled = true;
            comboBoxFiltMoney_SDN.Enabled = true;
            buttonNum_SDN.Enabled = true;
            buttonGraph_SDN.Enabled = true;
            textBoxSearch_SDN.Enabled = true;
            listBoxSort_SDN.Enabled = true;
            buttonVoz_SDN.Enabled = true;
            buttonUb_SDN.Enabled = true;
            numericUpDownFilCw_SDN.Enabled = true;
            buttonNum_SDN.Enabled = true;
            numericUpDownPad_SDN.Enabled = true;
            numericUpDownPods_SDN.Enabled = true;
            textBoxFamilia_SDN.Enabled = true;
            dateTimePickerDate_SDN.Enabled = true;
            numericUpDownCw_SDN.Enabled = true;
            numericUpDownK_SDN.Enabled = true;
            numericUpDownVal_SDN.Enabled = true;
            numericUpDownPolVal_SDN.Enabled = true;
            numericUpDownChild_SDN.Enabled = true;
            comboBoxMoney_SDN.Enabled = true;
            numericUpDownFamily_SDN.Enabled = true;
            textBoxPrim_SDN.Enabled = true;
            buttonDelete_SDN.Enabled = true;
            buttonRed_SDN.Enabled = true;
            buttonAdd_SDN.Enabled = true;
            buttonMin_SDN.Enabled = true;
            buttonMax_SDN.Enabled = true;
            buttonAverage_SDN.Enabled = true;
        }

        private void buttonAdd_SDN_Click(object sender, EventArgs e)
        {
            if ((textBoxFamilia_SDN.Text == "") || (comboBoxMoney_SDN.Text == "") || (textBoxPrim_SDN.Text == ""))
            {
                MessageBox.Show("Введите все данные для продолжения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridViewBase_SDN.Rows.Add(Convert.ToString(numericUpDownPods_SDN.Value), textBoxFamilia_SDN.Text, dateTimePickerDate_SDN.Text, Convert.ToString(numericUpDownCw_SDN.Value), Convert.ToString(numericUpDownK_SDN.Value), Convert.ToString(numericUpDownPolVal_SDN.Value), Convert.ToString(numericUpDownVal_SDN.Value), Convert.ToString(numericUpDownChild_SDN.Value), comboBoxMoney_SDN.Text, Convert.ToString(numericUpDownFamily_SDN.Value), textBoxPrim_SDN);
            }
        }

        private void buttonVoz_SDN_Click(object sender, EventArgs e)
        {
            if (listBoxSort_SDN.Items.Count != 0)
            {
                if ((string)listBoxSort_SDN.SelectedItem == "Фамилиям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[1], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Дате прописки")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[2], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Номеру квартиры")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[3], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству комнат")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[4], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Общим площадям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[5], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Полезным площадям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[6], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству детей")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[7], ListSortDirection.Ascending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству членов семьи")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[9], ListSortDirection.Ascending);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для сортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUb_SDN_Click(object sender, EventArgs e)
        {
            if (listBoxSort_SDN.Items.Count != 0)
            {
                if ((string)listBoxSort_SDN.SelectedItem == "Фамилиям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[1], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Дате прописки")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[2], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Номеру квартиры")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[3], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству комнат")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[4], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Общим площадям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[5], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Полезным площадям")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[6], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству детей")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[7], ListSortDirection.Descending);
                }
                if ((string)listBoxSort_SDN.SelectedItem == "Количеству членов семьи")
                {
                    dataGridViewBase_SDN.Sort(dataGridViewBase_SDN.Columns[9], ListSortDirection.Descending);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для сортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_SDN_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewBase_SDN.RowCount; i++)
                {
                    dataGridViewBase_SDN.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridViewBase_SDN.ColumnCount; j++)
                        if (dataGridViewBase_SDN.Rows[i].Cells[j].Value.ToString().Contains(textBoxSearch_SDN.Text))
                        {
                            dataGridViewBase_SDN.Rows[i].Selected = true;
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFilter_SDN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                string cellValue = row.Cells[8].Value.ToString();
                if (cellValue == (string)comboBoxFiltMoney_SDN.SelectedItem)
                {
                    row.Visible = true;

                }
                else
                {
                    row.Visible = false;
                }
            }

        }

        private void buttonFilterCansel_SDN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                row.Visible = true;
            }
        }

        private void buttonNum_SDN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                string cellValue = row.Cells[0].Value.ToString();
                string num = Convert.ToString(numericUpDownPad_SDN.Value);
                if (numericUpDownPad_SDN.Value > 0)
                {
                    if (cellValue == num)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка фильтрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRed_SDN_Click(object sender, EventArgs e)
        {
            int cur = dataGridViewBase_SDN.CurrentRow.Index;
            if ((textBoxFamilia_SDN.Text == "") || (comboBoxMoney_SDN.Text == "") || (textBoxPrim_SDN.Text == ""))
            {
                MessageBox.Show("Введите все данные для продолжения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridViewBase_SDN.Rows[cur].Cells[0].Value = Convert.ToString(numericUpDownPods_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[1].Value = textBoxFamilia_SDN.Text;
                dataGridViewBase_SDN.Rows[cur].Cells[2].Value = dateTimePickerDate_SDN.Text;
                dataGridViewBase_SDN.Rows[cur].Cells[3].Value = Convert.ToString(numericUpDownCw_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[4].Value = Convert.ToString(numericUpDownK_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[5].Value = Convert.ToString(numericUpDownVal_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[6].Value = Convert.ToString(numericUpDownPolVal_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[7].Value = Convert.ToString(numericUpDownChild_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[8].Value = comboBoxMoney_SDN.Text;
                dataGridViewBase_SDN.Rows[cur].Cells[9].Value = Convert.ToString(numericUpDownFamily_SDN.Value);
                dataGridViewBase_SDN.Rows[cur].Cells[10].Value = textBoxPrim_SDN.Text;

            }
        }



        private void buttonGraph_SDN_Click(object sender, EventArgs e)
        {
            chartFunc_SDN.Series.Clear();
            Series series = new Series();
            series.ChartType = SeriesChartType.Area;
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {

                double area = Convert.ToDouble(row.Cells[4].Value);
                int roomCount = Convert.ToInt32(row.Cells[5].Value);
                series.Points.AddXY(roomCount, area);
            }
            chartFunc_SDN.Series.Add(series);
            chartFunc_SDN.Show();
        }

        private void buttonMin_SDN_Click(object sender, EventArgs e)
        {
            double minValue = double.MaxValue;
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                {
                    double cellValue = Convert.ToDouble(row.Cells[5].Value);
                    if (cellValue < minValue)
                    {
                        minValue = cellValue;
                    }
                }
            }
            textBoxMin_SDN.Text = minValue.ToString();
        }

        private void buttonMax_SDN_Click(object sender, EventArgs e)
        {
            double maxValue = double.MinValue;
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                {
                    double cellValue = Convert.ToDouble(row.Cells[5].Value);
                    if (cellValue > maxValue)
                    {
                        maxValue = cellValue;
                    }
                }
            }
            textBoxMax_SDN.Text = maxValue.ToString();
        }

        private void buttonAverage_SDN_Click(object sender, EventArgs e)
        {
            double sum = 0;
            int count = 0;

            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                {
                    double cellValue = Convert.ToDouble(row.Cells[5].Value);
                    sum += cellValue;
                    count++;
                }
            }

            double average = sum / count;
            textBoxAverage_SDN.Text = Convert.ToString(Math.Round(average, 2));
        }



        private void buttonFiltCwi_SDN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBase_SDN.Rows)
            {
                string cellValue = row.Cells[4].Value.ToString();
                string num = Convert.ToString(numericUpDownFilCw_SDN.Value);
                if (numericUpDownPad_SDN.Value > 0)
                {
                    if (cellValue == num)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка фильтрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonHelp_SDN_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }
    }
}
