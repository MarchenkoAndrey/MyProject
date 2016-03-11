namespace Resettlement
{
    partial class UserInterface
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
        protected void InitializeComponent()
        {
            this.greedy_btn = new System.Windows.Forms.Button();
            this.fullSearch_btn = new System.Windows.Forms.Button();
            this.labelOne = new System.Windows.Forms.Label();
            this.squareOne_input = new System.Windows.Forms.TextBox();
            this.labelTwo = new System.Windows.Forms.Label();
            this.squareTwo_input = new System.Windows.Forms.TextBox();
            this.labelCountFloor = new System.Windows.Forms.Label();
            this.lossesTwo_label = new System.Windows.Forms.Label();
            this.lossesOne_label = new System.Windows.Forms.Label();
            this.realizat_label = new System.Windows.Forms.Label();
            this.resultFullSearch_label = new System.Windows.Forms.Label();
            this.resultGreedy_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valueQ = new System.Windows.Forms.TextBox();
            this.valueG = new System.Windows.Forms.TextBox();
            this.valueC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // greedy_btn
            // 
            this.greedy_btn.Location = new System.Drawing.Point(310, 134);
            this.greedy_btn.Name = "greedy_btn";
            this.greedy_btn.Size = new System.Drawing.Size(149, 23);
            this.greedy_btn.TabIndex = 0;
            this.greedy_btn.Text = "Эвристический алгоритм";
            this.greedy_btn.UseVisualStyleBackColor = true;
            this.greedy_btn.Click += new System.EventHandler(this.greedy_btn_Click);
            // 
            // fullSearch_btn
            // 
            this.fullSearch_btn.Location = new System.Drawing.Point(465, 134);
            this.fullSearch_btn.Name = "fullSearch_btn";
            this.fullSearch_btn.Size = new System.Drawing.Size(117, 23);
            this.fullSearch_btn.TabIndex = 1;
            this.fullSearch_btn.Text = "Полный перебор";
            this.fullSearch_btn.UseVisualStyleBackColor = true;
            this.fullSearch_btn.Click += new System.EventHandler(this.fullSearch_btn_Click);
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Location = new System.Drawing.Point(26, 45);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(278, 13);
            this.labelOne.TabIndex = 2;
            this.labelOne.Text = "Введите площади прямоугольников a(i) через пробел";
            this.labelOne.Click += new System.EventHandler(this.labelOne_Click);
            // 
            // squareOne_input
            // 
            this.squareOne_input.Location = new System.Drawing.Point(310, 42);
            this.squareOne_input.Name = "squareOne_input";
            this.squareOne_input.Size = new System.Drawing.Size(272, 20);
            this.squareOne_input.TabIndex = 3;
            this.squareOne_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelTwo
            // 
            this.labelTwo.AutoSize = true;
            this.labelTwo.Location = new System.Drawing.Point(26, 83);
            this.labelTwo.Name = "labelTwo";
            this.labelTwo.Size = new System.Drawing.Size(278, 13);
            this.labelTwo.TabIndex = 4;
            this.labelTwo.Text = "Введите площади прямоугольников b(i) через пробел";
            // 
            // squareTwo_input
            // 
            this.squareTwo_input.Location = new System.Drawing.Point(310, 80);
            this.squareTwo_input.Name = "squareTwo_input";
            this.squareTwo_input.Size = new System.Drawing.Size(272, 20);
            this.squareTwo_input.TabIndex = 5;
            // 
            // labelCountFloor
            // 
            this.labelCountFloor.AutoSize = true;
            this.labelCountFloor.Location = new System.Drawing.Point(26, 112);
            this.labelCountFloor.Name = "labelCountFloor";
            this.labelCountFloor.Size = new System.Drawing.Size(0, 13);
            this.labelCountFloor.TabIndex = 6;
            this.labelCountFloor.Click += new System.EventHandler(this.label1_Click);
            // 
            // lossesTwo_label
            // 
            this.lossesTwo_label.AutoSize = true;
            this.lossesTwo_label.Location = new System.Drawing.Point(23, 229);
            this.lossesTwo_label.Name = "lossesTwo_label";
            this.lossesTwo_label.Size = new System.Drawing.Size(0, 13);
            this.lossesTwo_label.TabIndex = 9;
            // 
            // lossesOne_label
            // 
            this.lossesOne_label.AutoSize = true;
            this.lossesOne_label.Location = new System.Drawing.Point(23, 207);
            this.lossesOne_label.Name = "lossesOne_label";
            this.lossesOne_label.Size = new System.Drawing.Size(0, 13);
            this.lossesOne_label.TabIndex = 8;
            // 
            // realizat_label
            // 
            this.realizat_label.AutoSize = true;
            this.realizat_label.Location = new System.Drawing.Point(23, 152);
            this.realizat_label.Name = "realizat_label";
            this.realizat_label.Size = new System.Drawing.Size(0, 13);
            this.realizat_label.TabIndex = 10;
            // 
            // resultFullSearch_label
            // 
            this.resultFullSearch_label.AutoSize = true;
            this.resultFullSearch_label.Location = new System.Drawing.Point(23, 172);
            this.resultFullSearch_label.Name = "resultFullSearch_label";
            this.resultFullSearch_label.Size = new System.Drawing.Size(0, 13);
            this.resultFullSearch_label.TabIndex = 20;
            // 
            // resultGreedy_label
            // 
            this.resultGreedy_label.AutoSize = true;
            this.resultGreedy_label.Location = new System.Drawing.Point(604, 152);
            this.resultGreedy_label.Name = "resultGreedy_label";
            this.resultGreedy_label.Size = new System.Drawing.Size(0, 13);
            this.resultGreedy_label.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Введите значение толщины стенки q";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Введите значение длины постоянного прямоугольника g";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Введите значение ширины прямоугольников с";
            // 
            // valueQ
            // 
            this.valueQ.Location = new System.Drawing.Point(900, 45);
            this.valueQ.Name = "valueQ";
            this.valueQ.Size = new System.Drawing.Size(40, 20);
            this.valueQ.TabIndex = 25;
            // 
            // valueG
            // 
            this.valueG.Location = new System.Drawing.Point(900, 72);
            this.valueG.Name = "valueG";
            this.valueG.Size = new System.Drawing.Size(40, 20);
            this.valueG.TabIndex = 26;
            // 
            // valueC
            // 
            this.valueC.Location = new System.Drawing.Point(900, 104);
            this.valueC.Name = "valueC";
            this.valueC.Size = new System.Drawing.Size(40, 20);
            this.valueC.TabIndex = 27;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 556);
            this.Controls.Add(this.valueC);
            this.Controls.Add(this.valueG);
            this.Controls.Add(this.valueQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultGreedy_label);
            this.Controls.Add(this.resultFullSearch_label);
            this.Controls.Add(this.realizat_label);
            this.Controls.Add(this.lossesTwo_label);
            this.Controls.Add(this.lossesOne_label);
            this.Controls.Add(this.labelCountFloor);
            this.Controls.Add(this.squareTwo_input);
            this.Controls.Add(this.labelTwo);
            this.Controls.Add(this.squareOne_input);
            this.Controls.Add(this.labelOne);
            this.Controls.Add(this.fullSearch_btn);
            this.Controls.Add(this.greedy_btn);
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button greedy_btn;
        private System.Windows.Forms.Button fullSearch_btn;
        private System.Windows.Forms.Label labelOne;
        private System.Windows.Forms.TextBox squareOne_input;
        private System.Windows.Forms.Label labelTwo;
        private System.Windows.Forms.TextBox squareTwo_input;
        private System.Windows.Forms.Label labelCountFloor;
        private System.Windows.Forms.Label lossesTwo_label;
        private System.Windows.Forms.Label lossesOne_label;
        private System.Windows.Forms.Label realizat_label;
//        private System.Windows.Forms.RadioButton radioButton1;
//        private System.Windows.Forms.RadioButton radioButton2;
//        private System.Windows.Forms.RadioButton radioButton3;
        protected System.Windows.Forms.Label resultFullSearch_label;
        protected System.Windows.Forms.Label resultGreedy_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox valueQ;
        private System.Windows.Forms.TextBox valueG;
        private System.Windows.Forms.TextBox valueC;
    }
}