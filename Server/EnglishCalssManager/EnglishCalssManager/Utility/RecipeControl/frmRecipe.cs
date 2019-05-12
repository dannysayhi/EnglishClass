using System;
using System.Linq;
using System.Windows.Forms;
using _4RobotSystem.RecipeControl;

namespace _4RobotSystem.RecipeTemp
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        private void frmRecipe_Load(object sender, EventArgs e)
        {
            Recipe_Manager.ReadAllRecipe();
            refreshCombieList();
            UILanguageSet();
        }

        //更新顯示資料
        private void refreshCombieList()
        {
            if (cbRecipeNO.Items.Count > 0)
            {
                cbRecipeNO.Items.Clear();
            }
            //Read            
            int iIndex = 0;
            for (int i = 0; i < Recipe_Manager._RecipeInfoGroup.lsRecipeInfo.Count; i++)
            {
                cbRecipeNO.Items.Add(Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[i].strRecipeNo);
                if (Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[i].strRecipeNo.Equals(Recipe_Manager._RecipeInfoGroup.strCurrentRecipeNo)) iIndex = i;                
            }
            cbRecipeNO.SelectedIndex = iIndex;
            tbRecipeName.Text = Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[iIndex].strRecipeName;
        }
        //新增工單名稱
        private void btn_add_Click(object sender, EventArgs e)
        {
            string strRecipeNO = cbRecipeNO.Text.Trim();
            string strRecipeName = tbRecipeName.Text.Trim();
            if (strRecipeNO.Equals(""))
            {
                MessageBox.Show("No RecipeID");
                return;
            }
            /*
            else
            {
                int outint;
                bool result = Int32.TryParse(strRecipeNO, out outint);
                if (!result)
                {
                    MessageBox.Show("底模代號輸入錯誤");
                    return;
                }
            }
            */

            for (int i = 0; i < Recipe_Manager._RecipeInfoGroup.lsRecipeInfo.Count; i++)
            {
                if (Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[i].strRecipeNo.Equals(strRecipeNO))
                {
                    MessageBox.Show("IDRepeat");
                    return;
                }                    
            }
            Recipe_Manager._RecipeInfoGroup.Add(strRecipeNO, strRecipeName);
            Recipe_Manager._RecipeInfoGroup.SetCurrentRecipe(strRecipeNO, strRecipeName);
            Recipe_Manager.WriteAllRecipe();
            Recipe_Manager.ReadAllRecipe();
            refreshCombieList();
            Recipe_Manager.bIsGetstrCurrentRecipe = true;
        }
        //刪除工單名稱
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DeleteC","ReConfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string strRecipeNO = cbRecipeNO.Text.Trim();
            if (strRecipeNO.Equals(""))
            {
                MessageBox.Show("NoRecipe");
                return;
            }
            Recipe_Manager._RecipeInfoGroup.Delete(cbRecipeNO.SelectedIndex);
            if (Recipe_Manager._RecipeInfoGroup.lsRecipeInfo.Count>0)
            {
                Recipe_Manager._RecipeInfoGroup.SetCurrentRecipe(Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strRecipeNo, Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strRecipeName);
            }
            else
            {
                Recipe_Manager._RecipeInfoGroup.SetCurrentRecipe(Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strDefaultRecipeNo, Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strDefaultRecipeName);
            }
            refreshCombieList();
            Recipe_Manager.WriteRecipeList();
            Recipe_Manager.ReadAllRecipe();
            Recipe_Manager.bIsGetstrCurrentRecipe = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strRecipeNO = cbRecipeNO.Text.Trim();
            if (strRecipeNO.Equals(""))
            {
                MessageBox.Show("NoRecipe");
                return;
            }           

            Recipe_Manager._RecipeInfoGroup.strCurrentRecipeNo= cbRecipeNO.Text.Trim();
            Recipe_Manager._RecipeInfoGroup.strCurrentRecipeName = tbRecipeName.Text.Trim();
            Recipe_Manager.WriteRecipeList();
            Recipe_Manager.ReadAllRecipe();
            Recipe_Manager.bIsGetstrCurrentRecipe = true;
            this.Close();
        }

        

        private void combo_Recipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Recipe_Manager._RecipeInfoGroup.lsRecipeInfo.Count == 0) return;
            if (cbRecipeNO.Items.Count == 0) return;
            tbRecipeName.Text = Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[cbRecipeNO.SelectedIndex].strRecipeName;
        }

        private void btn_Modifily_Click(object sender, EventArgs e)
        {
            Recipe_Manager._RecipeInfoGroup.Modify(cbRecipeNO.SelectedIndex, cbRecipeNO.Text.Trim(), tbRecipeName.Text.Trim());
            if (Recipe_Manager._RecipeInfoGroup.lsRecipeInfo.Count > 0)
            {
                Recipe_Manager._RecipeInfoGroup.SetCurrentRecipe(Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strRecipeNo, Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strRecipeName);
            }
            else
            {
                Recipe_Manager._RecipeInfoGroup.SetCurrentRecipe(Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strDefaultRecipeNo, Recipe_Manager._RecipeInfoGroup.lsRecipeInfo[0].strDefaultRecipeName);
            }
            refreshCombieList();
            Recipe_Manager.WriteRecipeList();
            Recipe_Manager.ReadAllRecipe();
            Recipe_Manager.bIsGetstrCurrentRecipe = true;
        }

        private void UILanguageSet()
        {
            this.Text ="ChangeRecipe";

            label1.Text = "ShoeID";
            label2.Text = "ShoeName";
            btnSelect.Text = "Select";
            btn_add.Text = "Add";
            btn_Delete.Text = "Delete";
            btn_Modifily.Text = "Modify";
        }
    }
}
