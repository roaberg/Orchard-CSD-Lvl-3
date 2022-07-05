
namespace Orchard_CSD_Lvl_3
{
    partial class ViewStats
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStats));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mrAppleDataSet1 = new Orchard_CSD_Lvl_3.MrAppleDataSet1();
            this.tblHarvestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblHarvestsTableAdapter = new Orchard_CSD_Lvl_3.MrAppleDataSet1TableAdapters.TblHarvestsTableAdapter();
            this.tableAdapterManager = new Orchard_CSD_Lvl_3.MrAppleDataSet1TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mrAppleDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHarvestsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(908, 569);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mrAppleDataSet1
            // 
            this.mrAppleDataSet1.DataSetName = "MrAppleDataSet1";
            this.mrAppleDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblHarvestsBindingSource
            // 
            this.tblHarvestsBindingSource.DataMember = "TblHarvests";
            this.tblHarvestsBindingSource.DataSource = this.mrAppleDataSet1;
            // 
            // tblHarvestsTableAdapter
            // 
            this.tblHarvestsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TblHarvestsTableAdapter = this.tblHarvestsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Orchard_CSD_Lvl_3.MrAppleDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ViewStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 472);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewStats";
            this.Text = "ViewStats";
            this.Load += new System.EventHandler(this.ViewStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mrAppleDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHarvestsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MrAppleDataSet1 mrAppleDataSet1;
        private System.Windows.Forms.BindingSource tblHarvestsBindingSource;
        private MrAppleDataSet1TableAdapters.TblHarvestsTableAdapter tblHarvestsTableAdapter;
        private MrAppleDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
    }
}