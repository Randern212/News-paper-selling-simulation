namespace NewspaperSellerSimulation
{
    partial class Form1
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
            this.LoadTestCases = new System.Windows.Forms.Button();
            this.dgvSimulationTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadTestCases
            // 
            this.LoadTestCases.Location = new System.Drawing.Point(144, 637);
            this.LoadTestCases.Name = "LoadTestCases";
            this.LoadTestCases.Size = new System.Drawing.Size(164, 37);
            this.LoadTestCases.TabIndex = 0;
            this.LoadTestCases.Text = "Load TestCase";
            this.LoadTestCases.UseVisualStyleBackColor = true;
            this.LoadTestCases.Click += new System.EventHandler(this.loadTestCasesButton);
            // 
            // dgvSimulationTable
            // 
            this.dgvSimulationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulationTable.Location = new System.Drawing.Point(12, 6);
            this.dgvSimulationTable.Name = "dgvSimulationTable";
            this.dgvSimulationTable.Size = new System.Drawing.Size(1057, 526);
            this.dgvSimulationTable.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 680);
            this.Controls.Add(this.dgvSimulationTable);
            this.Controls.Add(this.LoadTestCases);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulationTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadTestCases;
        private System.Windows.Forms.DataGridView dgvSimulationTable;
    }
}