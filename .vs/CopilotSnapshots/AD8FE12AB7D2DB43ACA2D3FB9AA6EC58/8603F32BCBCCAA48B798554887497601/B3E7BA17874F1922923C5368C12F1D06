using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1VPL
{
    public partial class MainForm : Form
    {
        List<Student> students = new List<Student>();

        // Define color scheme
        private readonly Color primaryColor = Color.FromArgb(0, 122, 204);      // Blue
        private readonly Color successColor = Color.FromArgb(40, 167, 69);       // Green
        private readonly Color dangerColor = Color.FromArgb(220, 53, 69);        // Red
        private readonly Color warningColor = Color.FromArgb(255, 193, 7);       // Yellow
        private readonly Color darkColor = Color.FromArgb(52, 58, 64);           // Dark Gray
        private readonly Color lightColor = Color.FromArgb(248, 249, 250);       // Light Gray

        public MainForm()
        {
            InitializeComponent();
            ApplyColorScheme();
        }

        private void ApplyColorScheme()
        {
            // Form background
            this.BackColor = lightColor;

            // Panel styling
            panelInput.BackColor = Color.White;
            panelSearch.BackColor = Color.White;

            // Labels styling
            lblId.ForeColor = darkColor;
            lblName.ForeColor = darkColor;
            lblMarks.ForeColor = darkColor;
            lblSearch.ForeColor = darkColor;
            lblStatus.ForeColor = primaryColor;
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);

            // Button styling
            StyleButton(button1, successColor);   // Add - Green
            StyleButton(button2, primaryColor);   // Update - Blue
            StyleButton(button3, dangerColor);    // Delete - Red
            StyleButton(button4, primaryColor);   // Search - Blue
            StyleButton(button5, warningColor);   // Count - Yellow

            // DataGridView styling
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = darkColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = primaryColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = darkColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // TextBox styling
            StyleTextBox(textBox1);
            StyleTextBox(textBox2);
            StyleTextBox(textBox3);
            StyleTextBox(textBox4);
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = backColor == warningColor ? darkColor : Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
        }

        private void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = darkColor;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading...";
            lblStatus.ForeColor = warningColor;
            
            List<Student> loadedStudents = await Task.Run(() => StudentRepository.Load());
            students = loadedStudents ?? new List<Student>();
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
            
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.ClearSelection();
            }
            
            lblStatus.Text = "Loaded Successfully";
            lblStatus.ForeColor = successColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                students.Add(new Student(
                    int.Parse(textBox1.Text),
                    textBox2.Text,
                    double.Parse(textBox3.Text)));

                RefreshGrid();
                StudentRepository.Save(students);
                ClearInputFields();
                lblStatus.Text = "Student added successfully";
                lblStatus.ForeColor = successColor;
            }
            catch
            {
                MessageBox.Show("Invalid Input! Please enter valid ID, Name, and Marks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error adding student";
                lblStatus.ForeColor = dangerColor;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                Student s = students.FirstOrDefault(x => x.Id == id);
                if (s != null)
                {
                    s.Name = textBox2.Text;
                    s.Marks = double.Parse(textBox3.Text);
                    RefreshGrid();
                    StudentRepository.Save(students);
                    ClearInputFields();
                    lblStatus.Text = "Student updated successfully";
                    lblStatus.ForeColor = successColor;
                }
                else
                {
                    MessageBox.Show("Student not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblStatus.Text = "Student not found";
                    lblStatus.ForeColor = warningColor;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input! Please enter valid ID and Marks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error updating student";
                lblStatus.ForeColor = dangerColor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0) return;
            
            var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                students.RemoveAll(s => s.Id == id);
                RefreshGrid();
                StudentRepository.Save(students);
                lblStatus.Text = "Student deleted successfully";
                lblStatus.ForeColor = successColor;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchText = textBox4.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
                lblStatus.Text = "Showing all students";
                lblStatus.ForeColor = primaryColor;
            }
            else
            {
                var filtered = students.Where(s => s.Name.ToLower().Contains(searchText)).ToList();
                dataGridView1.DataSource = filtered;
                lblStatus.Text = $"Found {filtered.Count} student(s)";
                lblStatus.ForeColor = primaryColor;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total Students: {students.Count}", "Student Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
    }
}
