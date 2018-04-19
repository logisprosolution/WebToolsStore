using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;

namespace WebToolsStore
{
    public partial class ProductPriceInfo : BasePage
    {
        #region Parameter
        ProductPriceBiz biz = new ProductPriceBiz();
        LoadExHelper loadEx = new LoadExHelper();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            base.dataId2 = ConvertHelper.ToInt(Request.QueryString["dataId2"]);
            loadEx.LoadUnit(ref ddl_unit, Enumerator.ConditionLoadEx.All);
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_product_price_code.ReadOnly = true;
            }
            else
            {
                txt_product_price_code.Text = biz.SelectMaxID();
            }
        }

        #endregion Override Methods

        #region Private Methods
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_product_price_code.Text = ConvertHelper.InitialValueDB(row, "product_price_code");
                    txt_product_price_name.Text = ConvertHelper.InitialValueDB(row, "product_price_name");
                    txt_cost.Text = ConvertHelper.InitialValueDB(row, "cost");
                    txt_price_Cash.Text = ConvertHelper.InitialValueDB(row, "price_Cash");
                    txt_price_Credit.Text = ConvertHelper.InitialValueDB(row, "price_Credit");
                    txt_price_CashExtra.Text = ConvertHelper.InitialValueDB(row, "price_CashExtra");
                    //int unitID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_id"));
                    //loadEx.LoadUnitById(ref ddl_unit, unitID, Enumerator.ConditionLoadEx.Else);
                    ddl_unit.SelectedValue = ConvertHelper.InitialValueDB(row, "unit_id");
                    ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
                    txtDescription.Text = ConvertHelper.InitialValueDB(row, "description");
                }
                else
                {
                    ShowMessage("ไม่พบข้อมูล");
                }
            }
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                MAS_Product_Price model = new MAS_Product_Price();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_product_price_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_product_price_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.product_price_id = base.dataId;
                }
                model.product_price_code = txt_product_price_code.Text;
                model.product_price_name = txt_product_price_name.Text;
                model.cost = ConvertHelper.ToDecimal(txt_cost.Text);
                model.price_Cash = ConvertHelper.ToDecimal(txt_price_Cash.Text);
                model.price_Credit = ConvertHelper.ToDecimal(txt_price_Credit.Text);
                model.price_CashExtra = ConvertHelper.ToDecimal(txt_price_CashExtra.Text);
                model.unit_id = ConvertHelper.ToInt(ddl_unit.SelectedValue);
                model.product_id = base.dataId2;
                model.is_del = false;
                model.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                model.description = txtDescription.Text;
                model.update_by = ApplicationWebInfo.UserID;
                int newDataId = biz.SaveData(model, base.SAVE_INFO, base.IsNewMode);
                model = null;
                GC.Collect();
                if (newDataId < 0)
                {
                    base.ShowMessage(FailMessage);
                }
                else
                {
                    //base.ShowMessage(SuccessMessage);
                    //if (base.IsNewMode)//บันทึกเสร็จแล้ว new mode จะทำการรีเฟรชข้อมูลใหม่
                    //{
                    //    LoadAfterNewMode(newDataId);
                    //}
                    if (base.IsNewMode)
                    {
                        base.ShowMessageAndRedirectBack(SuccessMessage, typeof(ProductInfo));
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion Private Methods

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(ProductInfo));
        }
        #endregion Events
    }
}