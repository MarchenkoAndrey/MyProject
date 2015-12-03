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
        private void InitializeComponent()
        {
            this.greedy_btn = new System.Windows.Forms.Button();
            this.fullSearch_btn = new System.Windows.Forms.Button();
            this.labelOne = new System.Windows.Forms.Label();
            this.squareOne_input = new System.Windows.Forms.TextBox();
            this.labelTwo = new System.Windows.Forms.Label();
            this.squareTwo_input = new System.Windows.Forms.TextBox();
            this.labelCountFloor = new System.Windows.Forms.Label();
            this.countFloor_input = new System.Windows.Forms.TextBox();
            this.lossesTwo_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lossesOne_label = new System.Windows.Forms.Label();
            this.realizat_label = new System.Windows.Forms.Label();
            this.timeFullSearch_label = new System.Windows.Forms.Label();
            this.resultFullSearch_label = new System.Windows.Forms.Label();
            this.minFine_label = new System.Windows.Forms.Label();
            this.optArrangeOne_label = new System.Windows.Forms.Label();
            this.optArrangeTwo_label = new System.Windows.Forms.Label();
            this.pleaseWaiting_label = new System.Windows.Forms.Label();
            this.resultGreedy_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // greedy_btn
            // 
            this.greedy_btn.Location = new System.Drawing.Point(289, 134);
            this.greedy_btn.Name = "greedy_btn";
            this.greedy_btn.Size = new System.Drawing.Size(119, 23);
            this.greedy_btn.TabIndex = 0;
            this.greedy_btn.Text = "Жадный алгоритм";
            this.greedy_btn.UseVisualStyleBackColor = true;
            this.greedy_btn.Click += new System.EventHandler(this.greedy_btn_Click);
            // 
            // fullSearch_btn
            // 
            this.fullSearch_btn.Location = new System.Drawing.Point(425, 134);
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
            this.labelOne.Size = new System.Drawing.Size(251, 13);
            this.labelOne.TabIndex = 2;
            this.labelOne.Text = "Введите площади однокомнатных через пробел";
            this.labelOne.Click += new System.EventHandler(this.labelOne_Click);
            // 
            // squareOne_input
            // 
            this.squareOne_input.Location = new System.Drawing.Point(289, 42);
            this.squareOne_input.Name = "squareOne_input";
            this.squareOne_input.Size = new System.Drawing.Size(253, 20);
            this.squareOne_input.TabIndex = 3;
            this.squareOne_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelTwo
            // 
            this.labelTwo.AutoSize = true;
            this.labelTwo.Location = new System.Drawing.Point(26, 83);
            this.labelTwo.Name = "labelTwo";
            this.labelTwo.Size = new System.Drawing.Size(249, 13);
            this.labelTwo.TabIndex = 4;
            this.labelTwo.Text = "Введите площади двухкомнатных через пробел";
            // 
            // squareTwo_input
            // 
            this.squareTwo_input.Location = new System.Drawing.Point(289, 80);
            this.squareTwo_input.Name = "squareTwo_input";
            this.squareTwo_input.Size = new System.Drawing.Size(253, 20);
            this.squareTwo_input.TabIndex = 5;
            this.squareTwo_input.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelCountFloor
            // 
            this.labelCountFloor.AutoSize = true;
            this.labelCountFloor.Location = new System.Drawing.Point(26, 112);
            this.labelCountFloor.Name = "labelCountFloor";
            this.labelCountFloor.Size = new System.Drawing.Size(150, 13);
            this.labelCountFloor.TabIndex = 6;
            this.labelCountFloor.Text = "Введите количество этажей";
            this.labelCountFloor.Click += new System.EventHandler(this.label1_Click);
            // 
            // countFloor_input
            // 
            this.countFloor_input.Location = new System.Drawing.Point(182, 112);
            this.countFloor_input.Name = "countFloor_input";
            this.countFloor_input.Size = new System.Drawing.Size(39, 20);
            this.countFloor_input.TabIndex = 7;
            this.countFloor_input.TextChanged += new System.EventHandler(this.countFloor_input_TextChanged);
            // 
            // lossesTwo_label
            // 
            this.lossesTwo_label.AutoSize = true;
            this.lossesTwo_label.Location = new System.Drawing.Point(23, 231);
            this.lossesTwo_label.Name = "lossesTwo_label";
            this.lossesTwo_label.Size = new System.Drawing.Size(0, 13);
            this.lossesTwo_label.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // lossesOne_label
            // 
            this.lossesOne_label.AutoSize = true;
            this.lossesOne_label.Location = new System.Drawing.Point(23, 209);
            this.lossesOne_label.Name = "lossesOne_label";
            this.lossesOne_label.Size = new System.Drawing.Size(0, 13);
            this.lossesOne_label.TabIndex = 8;
            // 
            // realizat_label
            // 
            this.realizat_label.AutoSize = true;
            this.realizat_label.Location = new System.Drawing.Point(23, 182);
            this.realizat_label.Name = "realizat_label";
            this.realizat_label.Size = new System.Drawing.Size(0, 13);
            this.realizat_label.TabIndex = 10;
            // 
            // timeFullSearch_label
            // 
            this.timeFullSearch_label.AutoSize = true;
            this.timeFullSearch_label.Location = new System.Drawing.Point(23, 260);
            this.timeFullSearch_label.Name = "timeFullSearch_label";
            this.timeFullSearch_label.Size = new System.Drawing.Size(0, 13);
            this.timeFullSearch_label.TabIndex = 11;
            // 
            // resultFullSearch_label
            // 
            this.resultFullSearch_label.AutoSize = true;
            this.resultFullSearch_label.Location = new System.Drawing.Point(23, 281);
            this.resultFullSearch_label.Name = "resultFullSearch_label";
            this.resultFullSearch_label.Size = new System.Drawing.Size(0, 13);
            this.resultFullSearch_label.TabIndex = 12;
            // 
            // minFine_label
            // 
            this.minFine_label.AutoSize = true;
            this.minFine_label.Location = new System.Drawing.Point(23, 305);
            this.minFine_label.Name = "minFine_label";
            this.minFine_label.Size = new System.Drawing.Size(0, 13);
            this.minFine_label.TabIndex = 13;
            // 
            // optArrangeOne_label
            // 
            this.optArrangeOne_label.AutoSize = true;
            this.optArrangeOne_label.Location = new System.Drawing.Point(23, 327);
            this.optArrangeOne_label.Name = "optArrangeOne_label";
            this.optArrangeOne_label.Size = new System.Drawing.Size(0, 13);
            this.optArrangeOne_label.TabIndex = 14;
            // 
            // optArrangeTwo_label
            // 
            this.optArrangeTwo_label.AutoSize = true;
            this.optArrangeTwo_label.Location = new System.Drawing.Point(23, 340);
            this.optArrangeTwo_label.Name = "optArrangeTwo_label";
            this.optArrangeTwo_label.Size = new System.Drawing.Size(0, 13);
            this.optArrangeTwo_label.TabIndex = 15;
            // 
            // pleaseWaiting_label
            // 
            this.pleaseWaiting_label.AutoSize = true;
            this.pleaseWaiting_label.Location = new System.Drawing.Point(625, 45);
            this.pleaseWaiting_label.Name = "pleaseWaiting_label";
            this.pleaseWaiting_label.Size = new System.Drawing.Size(0, 13);
            this.pleaseWaiting_label.TabIndex = 16;
            // 
            // resultGreedy_label
            // 
            this.resultGreedy_label.AutoSize = true;
            this.resultGreedy_label.Location = new System.Drawing.Point(565, 182);
            this.resultGreedy_label.Name = "resultGreedy_label";
            this.resultGreedy_label.Size = new System.Drawing.Size(0, 13);
            this.resultGreedy_label.TabIndex = 17;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 556);
            this.Controls.Add(this.resultGreedy_label);
            this.Controls.Add(this.pleaseWaiting_label);
            this.Controls.Add(this.optArrangeTwo_label);
            this.Controls.Add(this.optArrangeOne_label);
            this.Controls.Add(this.minFine_label);
            this.Controls.Add(this.resultFullSearch_label);
            this.Controls.Add(this.timeFullSearch_label);
            this.Controls.Add(this.realizat_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lossesTwo_label);
            this.Controls.Add(this.lossesOne_label);
            this.Controls.Add(this.countFloor_input);
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
        private System.Windows.Forms.TextBox countFloor_input;
        private System.Windows.Forms.Label lossesTwo_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lossesOne_label;
        private System.Windows.Forms.Label realizat_label;
        private System.Windows.Forms.Label timeFullSearch_label;
        private System.Windows.Forms.Label resultFullSearch_label;
        private System.Windows.Forms.Label minFine_label;
        private System.Windows.Forms.Label optArrangeOne_label;
        private System.Windows.Forms.Label optArrangeTwo_label;
        private System.Windows.Forms.Label pleaseWaiting_label;
        private System.Windows.Forms.Label resultGreedy_label;
    }
}