using System;
using System.Drawing;
using System.Windows.Forms;

namespace proga_4_1_cch_3sem
{
    public partial class Form1 : Form
    {
        // Переменная для хранения выбранной ячейки таблицы
        private Point? selectedCell;
        const int n = 5;
        const double x = 5;
        public Form1()
        {
            InitializeComponent();
            

            // Создание таблицы 5x5
            tableLayoutPanel1.RowCount = n; // Количество строк таблицы
            tableLayoutPanel1.ColumnCount = n; // Количество столбцов таблицы
            tableLayoutPanel1.AutoSize = false; // Отключаем автоматическое изменение размера таблицы
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25)); // Устанавливаем ширину столбца в 25 пикселей
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25)); // Устанавливаем высоту строки в 25 пикселей

            // Заполнение таблицы значениями
            FillTable(tableLayoutPanel1);

            // Добавление таблицы на форму
             // Закрепляем таблицу по краям формы
            tableLayoutPanel1.AutoScroll = true; // Включаем автопрокрутку, если таблица не помещается на форму
            Controls.Add(tableLayoutPanel1); // Добавляем таблицу на форму

            // Подключение обработчиков событий
            tableLayoutPanel1.MouseClick += tableLayoutPanel1_MouseDown; // Обработчик нажатия мыши на таблице

            // Добавление кнопки для сохранения таблицы
            button1.Click += button1_Click; // Обработчик нажатия кнопки
        }

        // Метод для заполнения таблицы значениями
        private void FillTable(TableLayoutPanel table)
        {
            for (int j = 0; j < table.ColumnCount; j++) // Цикл по столбцам таблицы
            {
                for (int i = 0; i < table.RowCount; i++) // Цикл по строкам таблицы
                {
                    double value = Math.Pow(x, j + 1); // Вычисление значения ячейки таблицы
                    TextBox textBox = new TextBox(); // Создание текстового поля для ячейки
                    textBox.Text = value.ToString(); // Установка текста в поле
                    textBox.ReadOnly = true; // Блокировка редактирования поля
                    textBox.MouseDown += textBox_MouseDown; // Подключение обработчика нажатия мыши на поле
                    table.Controls.Add(textBox, i, j); // Добавление поля в таблицу
                }
            }
        }

        // Обработчик нажатия кнопки "Сохранить"
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedCell.HasValue)
            {
                int column = selectedCell.Value.X;
                int row = selectedCell.Value.Y;
                Control control = tableLayoutPanel1.GetControlFromPosition(column, row);

                if (control is TextBox textBox)
                {
                    if (double.TryParse(textEdit1.Text, out double value))
                    {
                        textBox.Text = value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Введенное значение не является числом.", "Неверный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите ячейку.", "Ячейка не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Обработчик нажатия мыши на текстовом поле ячейки таблицы
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender; // Получение текстового поля ячейки таблицы
            textEdit1.Text = textBox.Text; // Установка текста из поля в textEdit1
            int column = tableLayoutPanel1.GetColumn(textBox); // Номер столбца, в котором находится поле
            int row = tableLayoutPanel1.GetRow(textBox); // Номер строки, в которой находится поле
            selectedCell = new Point(column, row); // Сохранение выбранной ячейки таблицы
        }

        // Обработчик нажатия мыши на таблице (не используется в данном примере)
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


