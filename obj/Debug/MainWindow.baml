   M S B A M L   `   `   `  ����E  AWheaterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WheaterApp
WheaterApp  5   	   E'clr-namespace:WheaterApp.MVVM.ViewModelWheaterApp.MVVM.ViewModel  5   	       WheaterApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WheaterApp     5   	   =	viewModel'clr-namespace:WheaterApp.MVVM.ViewModel     5   	   $	��700��5	   	   $
��1100��5
   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � DataContext 5      -   'WheaterApp.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#4A5762 �� CornerRadius$ 10��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5"      �� $��Weather App��5#      $��Center=�5$      $
��Left=�5%      
�������$��22(�5'      $��20,0,0,0q�5(      �� 5*      $��1��6   .+�5+      	� $��Weather��5,      $��50��5-      
�������$��14(�5/         MenuButtonTheme#��[  50       d� 	IsChecked$
 TrueY�51      ��52      �� *HomeViewCommand+	� 54      $
��Logs��55      $��50��56      
�������$��14(�58      #��[  59      ��5:      �� *LogsViewCommand+	� 5<      $��About��5=      $��50��5>      
�������$��14(�5@      #��[  5A      ��5B      �� *AboutViewCommand+	� 5D      -   5        $
��Exit��5E      $��50��5F      
�������$��14(�5H      #��[  5I      5J      5K      �� 5M      $��1��6   $��1��5N      $��10q�5O      ��5P      �� *CurrentView+5S      5T      5U      