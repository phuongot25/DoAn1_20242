<Window x:Class="DoAn1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:DoAn1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="60"/>
            <RowDefinition />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="200" />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Border Grid.Row="0"
                Grid.Column="0"
                x:Name="CaptionContent"
                Background="PapayaWhip" >
        </Border>


        <Border Grid.Row="0"
                Grid.Column="1"
                x:Name="BannerContent"
                Background="Gray">
        </Border>

        <Border Grid.Row="1"
                Grid.Column="0"
                x:Name="SideMenuContent"
                Background="Gray">
        </Border>

        <Border Grid.Row="1"
                Grid.Column="1"
                x:Name="MainContent"
                Background="IndianRed">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="50" />
                    <RowDefinition />
                    <RowDefinition Height="30" />
                </Grid.RowDefinitions>
                <Border Grid.Row="0" x:Name="Header">

                    <Grid>

                        <TextBlock Text="{Binding Path= Title}" 
                            x:Name="PageTitle" />

                    </Grid>
                </Border>
                <Border Grid.Row="1" x:Name="Body">
                    <DataGrid x:Name="MainDataView" DataContext="{Binding Path = Data}" SelectionChanged="MainDataView_SelectionChanged"  />
                </Border>
                <Border Grid.Row="2" x:Name="Footer">
                    <Grid>
                        <TextBlock x:Name="Summary" Text="{Binding Path=Total}" />
                    </Grid>
                </Border>
            </Grid>
        </Border>
    </Grid>
</Window>
