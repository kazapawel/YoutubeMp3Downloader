   M S B A M L   `   `   `  ????G  CYoutubeToMp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:YoutubeToMp3YoutubeToMp3  5   	       YoutubeToMp3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:YoutubeToMp3     5   	   3fa$http://schemas.fontawesome.io/icons/     5   	     ? Title$  
MainWindow??5	   	   $	??370??5
   	   $	??370??5   	   $	??652??5   	   $	??652??5   	      MainWindowModernStyle#??[  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Icon$. (pack://application:,,,/Images/yticon.png??5   	    ? DataContext 5      '   !YoutubeToMp3.ApplicationViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      $
??auto ?6   .+?5&   
   ? $??0??6    ? ColumnDefinitions 5)      ?? 5,      $
??auto ?6#   ?? 5/      $??* ?6#   ?? 52      $
??auto ?6#   ?? 55      $
??auto ?6#   .+?5;      ?? -   5        $??2??5;        ButtonImageStyle#??[ 5<       ! BackgroundDarkSimpleMainBrush#??[ 5=      
 ? Tag$7 1pack://application:,,,/Images/minimize_modern.png??5>      5?      ?? 5B      -   5        $??3??5B      
???  ??#??[ 5D      $4 .pack://application:,,,/Images/close_modern.png??5E      5F      5I         YoutubeToMp3.MainControl  5N   
   $??1??6    5O      ?? *MainViewModel+   TextChangedCommand 5P      ?? *GetInfoCommandAsync+5U      5V      