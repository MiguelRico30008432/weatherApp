   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ControlForeground  ControlReadOnlyForeground  ControlDisabledForeground  ControlBackground  ControlHoveredBackground  ControlFocusedBackground  ControlReadOnlyBackground  ControlDisabledBackground  ControlBorder 	 ControlHoveredBorder 
 ControlFocusedBorder  ControlReadOnlyBorder  ControlDisabledBorder  TextBoxTemplateBase  �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� 	BeginTime g� Duration W� From	 W� To	 �� TargetProperty
 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name J� Opacity �� Color ��Name �� Triggers P� Property P� Value �� Property �� Value  TextBoxBaseStyle �� 
TargetType�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %J  &	        &	      &	 >     &	 ]     &	 |     &	 �     &	 �     &	 �     &	 �     &		     &	
 8    &	 W    &	 v    &	 �    7  7  7  7  7 	 7  7 
 7  7  7  &	 �    7  7   7  7  ��5      #181818��6/   ��5      #383838��67   ��5      #686868��67   ��5	      #ABABAB��6/   ��5
      #fafafc��66   ��5      #fdfdff��66   ��5      #f2f2f4��67   ��5      #efeff2��67   ��5      #383838��6+   ��5      	#FF5096D6��64   ��5      #000000��62   ��5      #484848��63   ��5      #787878��63   �� 5      "  ��62   .R�5   
   � $
 root��6   #��z��6   #��z��6?    5        5      CommonStates��. 5        
Normal��. 5      �� .��5      W� $ 00:00:00.000X�6.   $ 00:00:00.500D�6G   $ 1X�5   .   $ 0X�67   $	 Opacity�5   .   $
 hoverBorder��5    .   5!      5"        5#      	MouseOver��. 5$      �� .��5%      W� $ 00:00:00.000X�6.   $ 00:00:00.500D�6G   $ 0X�5&   .   $ 1X�67   $	 Opacity�5'   .   $
 hoverBorder��5(   .   5)      5*        5+      Disabled��. 5,      �� .��5-      �� $
 normalBorder��6;   $1	 +(Border.Background).(SolidColorBrush.Color)�5.   ;   .g�5/   "     $ 0��66   8   6B   50      �� 51      $
 normalBorder��6;   $2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�52   ;   .g�53   "     $ 0��66   8  6B   54      55      56        57      ReadOnly��. 58      �� .��59      �� $
 normalBorder��6;   $1	 +(Border.Background).(SolidColorBrush.Color)�5:   ;   .g�5;   "     $ 0��66   8  6B   5<      �� 5=      $
 normalBorder��6;   $2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�5>   ;   .g�5?   "     $ 0��66   8  6B   5@      5A      5B      5C        5D      FocusStates��. 5E        Focused��. 5F      �� .��5G      W� $ 00:00:00.000X�6.   $ 00:00:00.300D�6G   $ 0X�5H   .   $ 1X�67   $	 Opacity�5I   .   $
 focusBorder��5J   .   5K      5L        5M      	Unfocused��. 5N      �� .��5O      W� $ 00:00:00.000X�6.   $ 00:00:00.700D�6G   $ 1X�5P   .   $ 0X�67   $	 Opacity�5Q   .   $
 focusBorder��5R   .   5S      5T      5U      .+�5Y      �� $ normalBorder��6   #��z��5Z      #��z��5[      #��z��5\      �� 5_      $ hoverBorder��6   $ 0Q�6*   #��z��5`      ��5a      �� 5b      8  6&   ��5d      �� 5e      8  6&   5g      �� 5j      $ focusBorder��6   $ 0Q�6*   #��z��5k      ��5l      �� 5m      8  6&   ��5o      �� 5p      8  6&   5r      �� 5u      $ PART_ContentHost��6   #��z��5v      $��0q�5w      ��.  $��2q�5y      #��z��5{      #��z��5|      #��z��5}      ��5z      Z� 5}      5       5�   
   P� 5�       � {� .  . �5�      ��  � �� 5�      �� 5�      8  6*   5�      5�      P� 5�       �@��
IsReadOnly . . �5�      ��  � �� 5�      �� 5�      8 	 6*   5�      5�      5�      �� 5�      " ��6%   .�5�   
   ��  � �� 5�      �� 5�      8   6"   5�      �� 5�   
    � �� 5�      �� 5�      8  6"   5�      �� 5�   
    � ��$	 8 4q�6$   �� 5�   
    � ��$ Stretch=�60   �� 5�   
    � ��$
 Left=�67   �� 5�   
    � ��$ Stretch=�6.   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � �� 5�      �� 5�      8  6"   5�      �� 5�   
    � ��8  6%   5�      5�      