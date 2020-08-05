# How to update the header height on scrolling in Xamarin.Forms ListView (SfListView)

The Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) allows you to change the stack height based on scroll using [SfListView.ExtendedScrollView](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ExtendedScrollView.html?) scrolled event. Based on the minimum and maximum value of the scroll offset, you can change the height for the [StackLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/stacklayout).

You can also refer the following article.

https://www.syncfusion.com/kb/11830/how-to-update-the-header-height-on-scrolling-in-xamarin-forms-listview-sflistview

**XAML**

**StackLayout** is used as a header of the ListView.

``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage" Padding="{OnPlatform iOS='0,40,0,0'}">
    <ContentPage.BindingContext>
        <local:ContactsViewModel/>
    </ContentPage.BindingContext>
    <ContentPage.Behaviors>
        <local:Behavior/>
    </ContentPage.Behaviors>
    <ContentPage.Content>
        <StackLayout >
            <StackLayout x:Name="headerStack" BackgroundColor="Teal" HeightRequest="100">
                <Label Text="Header" TextColor="White" HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand"/>
            </StackLayout>
            <syncfusion:SfListView x:Name="listView" ItemSize="60" ItemsSource="{Binding ContactsInfo}">
                <syncfusion:SfListView.ItemTemplate >
                    <DataTemplate>
                        <Grid x:Name="grid">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Image Source="{Binding ContactImage}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="50" WidthRequest="50"/>
                            <Grid Grid.Column="1" RowSpacing="1" Padding="10,0,0,0" VerticalOptions="Center">
                                <Label LineBreakMode="NoWrap" TextColor="#474747" Text="{Binding ContactName}"/>
                                <Label Grid.Row="1" Grid.Column="0" TextColor="#474747" LineBreakMode="NoWrap" Text="{Binding ContactNumber}"/>
                            </Grid>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

**C#**

You can get the **ExtendedScrollView** by using the [SfListView.GetScrollView](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.Control.Helpers.SfListViewHelper~GetScrollView.html?) method and trigger the  [Scrolled](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.scrollview.scrolled) event.

``` c#
using Syncfusion.ListView.XForms.Control.Helpers;
namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView ListView;
        StackLayout Header;
        double minHeight = 50;
        double maxHeight = 100;
 
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            Header = bindable.FindByName<StackLayout>("headerStack");
            var scrollView = ListView.GetScrollView();
            scrollView.Scrolled += ScrollView_Scrolled;
            base.OnAttachedTo(bindable);
        }
 
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
    }
}
```
**Output**

![HeaderHeightUpdate](https://github.com/SyncfusionExamples/header-height-update-on-scrolling-listview-xamarin/blob/master/ScreenShot/HeaderHeightUpdate.gif)
