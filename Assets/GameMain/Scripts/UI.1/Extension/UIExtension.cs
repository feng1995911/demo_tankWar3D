using System.Collections;
using FairyGUI;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.UI;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class UIExtension
    {
        public static IEnumerator FadeToAlpha(this GComponent canvasGroup, float alpha, float duration)
        {
            float time = 0f;
            float originalAlpha = canvasGroup.alpha;
            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }

        public static IEnumerator SmoothValue(this GSlider slider, float value, float duration)
        {
            float time = 0f;
            float originalValue = (float)slider.value;
            while (time < duration)
            {
                time += Time.deltaTime;
                slider.value = Mathf.Lerp(originalValue, value, time / duration);
                yield return new WaitForEndOfFrame();
            }

            slider.value = value;
        }

        public static bool HasUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
        {
            return uiComponent.HasUIForm((int)uiFormId, uiGroupName);
        }

        public static bool HasUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
        {
            IDataTable<DRUIForm> dtUIForm = GameEntry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                return false;
            }

            string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
            if (string.IsNullOrEmpty(uiGroupName))
            {
                return uiComponent.HasUIForm(assetName);
            }

            IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return false;
            }

            return uiGroup.HasUIForm(assetName);
        }

        public static FairyGuiForm GetUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
        {
            return uiComponent.GetUIForm((int)uiFormId, uiGroupName);
        }

        public static FairyGuiForm GetUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
        {
            IDataTable<DRUIForm> dtUIForm = GameEntry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                return null;
            }

            string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
            UIForm uiForm = null;
            if (string.IsNullOrEmpty(uiGroupName))
            {
                uiForm = uiComponent.GetUIForm(assetName);
                if (uiForm == null)
                {
                    return null;
                }

                return (FairyGuiForm)uiForm.Logic;
            }

            IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return null;
            }

            uiForm = (UIForm)uiGroup.GetUIForm(assetName);
            if (uiForm == null)
            {
                return null;
            }

            return (FairyGuiForm)uiForm.Logic;
        }

        public static void CloseUIForm(this UIComponent uiComponent, UIFormId uiFormId)
        {
            FairyGuiForm form = uiComponent.GetUIForm(uiFormId);
            uiComponent.CloseUIForm(form);
        }

        public static void CloseUIForm(this UIComponent uiComponent, FairyGuiForm uiForm)
        {
            if (uiForm != null)
                uiComponent.CloseUIForm(uiForm.UIForm);
        }

        public static UIFormLogic OpenAndGetForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            int? id = uiComponent.OpenUIForm(uiFormId, userData);
            if (!id.HasValue)
            {
                Log.Error("Open form fail.");
                return null;
            }

            return uiComponent.GetUIForm(id.Value).Logic;
        }

        public static int? OpenUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenUIForm((int)uiFormId, userData);
        }

        public static int? OpenUIForm(this UIComponent uiComponent, int uiFormId, object userData = null)
        {
            IDataTable<DRUIForm> dtUIForm = GameEntry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                Log.Warning("Can not load UI form '{0}' from data table.", uiFormId.ToString());
                return null;
            }

            string assetName = AssetUtility.GetUIFormAsset(drUIForm.AssetName);
            if (!drUIForm.AllowMultiInstance)
            {
                if (uiComponent.IsLoadingUIForm(assetName))
                {
                    return null;
                }

                if (uiComponent.HasUIForm(assetName))
                {
                    return null;
                }
            }

            return uiComponent.OpenUIForm(assetName, drUIForm.UIGroupName, drUIForm.PauseCoveredUIForm, userData);
        }

        public static void OpenDialog(this UIComponent uiComponent, DialogFormData dialogParams)
        {
            if (((ProcedureBase)GameEntry.Procedure.CurrentProcedure).UseNativeDialog)
            {
                OpenNativeDialog(dialogParams);
            }
            else
            {
                uiComponent.OpenUIForm(UIFormId.DialogForm, dialogParams);
            }
        }

        private static void OpenNativeDialog(DialogFormData dialogParams)
        {
            // TODO：这里应该弹出原生对话框，先简化实现为直接按确认按钮
            if (dialogParams.OnClickConfirm != null)
            {
                dialogParams.OnClickConfirm(dialogParams.UserData);
            }
        }
    }

}
