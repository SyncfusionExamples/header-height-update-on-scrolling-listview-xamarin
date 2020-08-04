using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields
        SfListView ListView;
        StackLayout Header;
        double minHeight = 50;
        double maxHeight = 100;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            Header = bindable.FindByName<StackLayout>("headerStack");
            var scrollView = ListView.GetScrollView();
            scrollView.Scrolled += ScrollView_Scrolled;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView = null;
            Header = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Event
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY > 10 && Header.HeightRequest > minHeight)
            {
                Header.HeightRequest = minHeight;
            }
            else if (e.ScrollY < 10 && Header.HeightRequest < maxHeight)
            {
                Header.HeightRequest = maxHeight;
            }
        }
        #endregion
    }
}