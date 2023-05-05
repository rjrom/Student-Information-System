
namespace StudentInfo
{
    partial class SubjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.textBox3_SubjectTitle = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2_SubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddCourse = new System.Windows.Forms.Button();
            this.buttonDeleteCourse = new System.Windows.Forms.Button();
            this.buttonModifyCourse = new System.Windows.Forms.Button();
            this.comboBox1_Year = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBox1_Course = new System.Windows.Forms.ComboBox();
            this.comboBox2_Semester = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4_Units = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(674, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1110, 359);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(84)))), ((int)(((byte)(156)))));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 49);
            this.panel2.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(87, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Manage Subject";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(71)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.iconButton7);
            this.panel1.Controls.Add(this.iconButton6);
            this.panel1.Controls.Add(this.iconButton5);
            this.panel1.Controls.Add(this.iconButton4);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 864);
            this.panel1.TabIndex = 40;
            // 
            // iconButton7
            // 
            this.iconButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton7.FlatAppearance.BorderSize = 0;
            this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.iconButton7.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton7.IconSize = 40;
            this.iconButton7.Location = new System.Drawing.Point(0, 408);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Size = new System.Drawing.Size(143, 68);
            this.iconButton7.TabIndex = 10;
            this.iconButton7.Text = "Subjects";
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = true;
            // 
            // iconButton6
            // 
            this.iconButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.Uikit;
            this.iconButton6.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 40;
            this.iconButton6.Location = new System.Drawing.Point(0, 340);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Size = new System.Drawing.Size(143, 68);
            this.iconButton6.TabIndex = 7;
            this.iconButton6.Text = "Rooms";
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconButton5.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 40;
            this.iconButton5.Location = new System.Drawing.Point(0, 272);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(143, 68);
            this.iconButton5.TabIndex = 6;
            this.iconButton5.Text = "Schedule";
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = true;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // iconButton4
            // 
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconButton4.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 40;
            this.iconButton4.Location = new System.Drawing.Point(0, 204);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(143, 68);
            this.iconButton4.TabIndex = 5;
            this.iconButton4.Text = "Section";
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = true;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChalkboardTeacher;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 40;
            this.iconButton3.Location = new System.Drawing.Point(0, 136);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(143, 68);
            this.iconButton3.TabIndex = 4;
            this.iconButton3.Text = "Teachers";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 40;
            this.iconButton2.Location = new System.Drawing.Point(0, 68);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(143, 68);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.Text = "Course";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(143, 68);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Students";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // textBox3_SubjectTitle
            // 
            this.textBox3_SubjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox3_SubjectTitle.Location = new System.Drawing.Point(233, 308);
            this.textBox3_SubjectTitle.Multiline = true;
            this.textBox3_SubjectTitle.Name = "textBox3_SubjectTitle";
            this.textBox3_SubjectTitle.Size = new System.Drawing.Size(327, 31);
            this.textBox3_SubjectTitle.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(229, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 20);
            this.label13.TabIndex = 72;
            this.label13.Text = "Subject Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(229, 353);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 71;
            this.label5.Text = "Units";
            // 
            // textBox2_SubjectCode
            // 
            this.textBox2_SubjectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox2_SubjectCode.Location = new System.Drawing.Point(233, 233);
            this.textBox2_SubjectCode.Multiline = true;
            this.textBox2_SubjectCode.Name = "textBox2_SubjectCode";
            this.textBox2_SubjectCode.Size = new System.Drawing.Size(327, 31);
            this.textBox2_SubjectCode.TabIndex = 65;
            this.textBox2_SubjectCode.TextChanged += new System.EventHandler(this.textBox2_CourseCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Subject Code";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Course Code";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(229, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 63;
            this.label1.Text = "Manage Subject";
            // 
            // buttonAddCourse
            // 
            this.buttonAddCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonAddCourse.Location = new System.Drawing.Point(185, 608);
            this.buttonAddCourse.Name = "buttonAddCourse";
            this.buttonAddCourse.Size = new System.Drawing.Size(117, 64);
            this.buttonAddCourse.TabIndex = 73;
            this.buttonAddCourse.Text = "Create Subject";
            this.buttonAddCourse.UseVisualStyleBackColor = true;
            this.buttonAddCourse.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDeleteCourse
            // 
            this.buttonDeleteCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonDeleteCourse.Location = new System.Drawing.Point(466, 608);
            this.buttonDeleteCourse.Name = "buttonDeleteCourse";
            this.buttonDeleteCourse.Size = new System.Drawing.Size(117, 64);
            this.buttonDeleteCourse.TabIndex = 74;
            this.buttonDeleteCourse.Text = "Delete Subject";
            this.buttonDeleteCourse.UseVisualStyleBackColor = true;
            this.buttonDeleteCourse.Click += new System.EventHandler(this.DeleteCourseButton_Click);
            // 
            // buttonModifyCourse
            // 
            this.buttonModifyCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModifyCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonModifyCourse.Location = new System.Drawing.Point(325, 608);
            this.buttonModifyCourse.Name = "buttonModifyCourse";
            this.buttonModifyCourse.Size = new System.Drawing.Size(117, 64);
            this.buttonModifyCourse.TabIndex = 75;
            this.buttonModifyCourse.Text = "Edit Subject";
            this.buttonModifyCourse.UseVisualStyleBackColor = true;
            this.buttonModifyCourse.Click += new System.EventHandler(this.ModifyCourseButton_Click);
            // 
            // comboBox1_Year
            // 
            this.comboBox1_Year.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_Year.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBox1_Year.FormattingEnabled = true;
            this.comboBox1_Year.ItemHeight = 24;
            this.comboBox1_Year.Items.AddRange(new object[] {
            "First Year",
            "Second Year",
            "Third Year",
            "Fourth Year"});
            this.comboBox1_Year.Location = new System.Drawing.Point(233, 451);
            this.comboBox1_Year.Name = "comboBox1_Year";
            this.comboBox1_Year.Size = new System.Drawing.Size(327, 32);
            this.comboBox1_Year.TabIndex = 81;
            this.comboBox1_Year.SelectedIndexChanged += new System.EventHandler(this.comboBox1_Course_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(229, 428);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 83;
            this.label9.Text = "Year";
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(975, 106);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(95, 26);
            this.Search.TabIndex = 85;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textSearch.Location = new System.Drawing.Point(674, 106);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(282, 26);
            this.textSearch.TabIndex = 84;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            this.textSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSearch_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonCancel.Location = new System.Drawing.Point(605, 608);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(117, 64);
            this.buttonCancel.TabIndex = 86;
            this.buttonCancel.Text = "Clear";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBox1_Course
            // 
            this.comboBox1_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_Course.FormattingEnabled = true;
            this.comboBox1_Course.Location = new System.Drawing.Point(233, 164);
            this.comboBox1_Course.Name = "comboBox1_Course";
            this.comboBox1_Course.Size = new System.Drawing.Size(327, 28);
            this.comboBox1_Course.TabIndex = 87;
            // 
            // comboBox2_Semester
            // 
            this.comboBox2_Semester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2_Semester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2_Semester.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2_Semester.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBox2_Semester.FormattingEnabled = true;
            this.comboBox2_Semester.ItemHeight = 24;
            this.comboBox2_Semester.Items.AddRange(new object[] {
            "First Sem",
            "Second Sem"});
            this.comboBox2_Semester.Location = new System.Drawing.Point(233, 531);
            this.comboBox2_Semester.Name = "comboBox2_Semester";
            this.comboBox2_Semester.Size = new System.Drawing.Size(327, 32);
            this.comboBox2_Semester.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 508);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "Semester";
            // 
            // textBox4_Units
            // 
            this.textBox4_Units.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox4_Units.Location = new System.Drawing.Point(233, 380);
            this.textBox4_Units.Multiline = true;
            this.textBox4_Units.Name = "textBox4_Units";
            this.textBox4_Units.Size = new System.Drawing.Size(327, 31);
            this.textBox4_Units.TabIndex = 90;
            this.textBox4_Units.TextChanged += new System.EventHandler(this.textBox4_Units_TextChanged_1);
            this.textBox4_Units.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_Units_KeyPress);
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1924, 913);
            this.Controls.Add(this.textBox4_Units);
            this.Controls.Add(this.comboBox2_Semester);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1_Course);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.comboBox1_Year);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonModifyCourse);
            this.Controls.Add(this.buttonDeleteCourse);
            this.Controls.Add(this.buttonAddCourse);
            this.Controls.Add(this.textBox3_SubjectTitle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2_SubjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SubjectForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox textBox3_SubjectTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2_SubjectCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddCourse;
        private System.Windows.Forms.Button buttonDeleteCourse;
        private System.Windows.Forms.Button buttonModifyCourse;
        private System.Windows.Forms.ComboBox comboBox1_Year;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBox1_Course;
        private System.Windows.Forms.ComboBox comboBox2_Semester;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconButton7;
        private System.Windows.Forms.TextBox textBox4_Units;
    }
}