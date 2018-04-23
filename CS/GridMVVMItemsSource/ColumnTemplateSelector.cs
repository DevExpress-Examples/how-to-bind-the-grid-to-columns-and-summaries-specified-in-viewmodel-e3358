using System.Windows.Controls;
using System.Windows;
using Model;
using DevExpress.Xpf.Core.Native;

namespace View {
    public class ColumnTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Column column = (Column)item;
#if SILVERLIGHT
            return (DataTemplate)LayoutHelper.FindParentObject<UserControl>(container).Resources[column.Settings + "ColumnTemplate"];
#else
            return (DataTemplate)((Control)container).FindResource(column.Settings + "ColumnTemplate");
#endif
        }
    }
}