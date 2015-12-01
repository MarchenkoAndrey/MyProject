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
            this.SuspendLayout();
            // 
            // greedy_btn
            // 
            this.greedy_btn.Location = new System.Drawing.Point(29, 134);
            this.greedy_btn.Name = "greedy_btn";
            this.greedy_btn.Size = new System.Drawing.Size(119, 23);
            this.greedy_btn.TabIndex = 0;
            this.greedy_btn.Text = "Жадный алгоритм";
            this.greedy_btn.UseVisualStyleBackColor = true;
            this.greedy_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // fullSearch_btn
            // 
            this.fullSearch_btn.Location = new System.Drawing.Point(168, 134);
            this.fullSearch_btn.Name = "fullSearch_btn";
            this.fullSearch_btn.Size = new System.Drawing.Size(106, 23);
            this.fullSearch_btn.TabIndex = 1;
            this.fullSearch_btn.Text = "Полный перебор";
            this.fullSearch_btn.UseVisualStyleBackColor = true;
            this.fullSearch_btn.Click += new System.EventHandler(this.fullSearch_btn_Click);
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Location = new System.Drawing.Point(26, 42);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(124, 13);
            this.labelOne.TabIndex = 2;
            this.labelOne.Text = "Введите площади один";
            // 
            // squareOne_input
            // 
            this.squareOne_input.Location = new System.Drawing.Point(168, 42);
            this.squareOne_input.Name = "squareOne_input";
            this.squareOne_input.Size = new System.Drawing.Size(131, 20);
            this.squareOne_input.TabIndex = 3;
            this.squareOne_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelTwo
            // 
            this.labelTwo.AutoSize = true;
            this.labelTwo.Location = new System.Drawing.Point(26, 87);
            this.labelTwo.Name = "labelTwo";
            this.labelTwo.Size = new System.Drawing.Size(122, 13);
            this.labelTwo.TabIndex = 4;
            this.labelTwo.Text = "Введите площади двух";
            // 
            // squareTwo_input
            // 
            this.squareTwo_input.Location = new System.Drawing.Point(168, 84);
            this.squareTwo_input.Name = "squareTwo_input";
            this.squareTwo_input.Size = new System.Drawing.Size(131, 20);
            this.squareTwo_input.TabIndex = 5;
            this.squareTwo_input.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelCountFloor
            // 
            this.labelCountFloor.AutoSize = true;
            this.labelCountFloor.Location = new System.Drawing.Point(382, 42);
            this.labelCountFloor.Name = "labelCountFloor";
            this.labelCountFloor.Size = new System.Drawing.Size(150, 13);
            this.labelCountFloor.TabIndex = 6;
            this.labelCountFloor.Text = "Введите количество этажей";
            this.labelCountFloor.Click += new System.EventHandler(this.label1_Click);
            // 
            // countFloor_input
            // 
            this.countFloor_input.Location = new System.Drawing.Point(547, 35);
            this.countFloor_input.Name = "countFloor_input";
            this.countFloor_input.Size = new System.Drawing.Size(100, 20);
            this.countFloor_input.TabIndex = 7;
            this.countFloor_input.TextChanged += new System.EventHandler(this.countFloor_input_TextChanged);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 365);
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
    }
}