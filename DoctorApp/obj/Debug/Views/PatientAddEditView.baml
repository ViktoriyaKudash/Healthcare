   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5      "    DoctorApp.PatientAddEditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:DoctorApp     5        � WindowStartupLocation$  CenterScreen=�5       � Title$ PatientWindow��5
      $	��300��5      $	��450��5         DoctorApp.DialogCloser   DialogResult 5	      �� *DialogResult+��5      �� 5   
    �� ImageSource$ ../Resources/1414.jpg��6    �� Opacity$	 0.9Q�69    � 	Resources 5      +   %DoctorApp.ImageToImageSourceConverter   ImageToImageSourceConverter��%   &	          5      6&   5      .��5      �  � RowDefinitions 5      �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!      � $��1��6	   $��1��5"       5#      �� 5$      $��* �6   �� 5%      $
��auto �6   .+�5(      �� $��64��6   $��64��5)      $	��128��5*      $	��128��5+      $��5q�5,      ��5-      �� *Photo+ �� 	Converter# [  �� 5/      $��1��6   $��Select Photo��50      $��5q�52      ��51      �� *SelectPhotoCommand+52      53      � 55      $��1��6	   $��2��56       57      �� 58      $
��auto �6   �� 59      $
��auto �6   �� 5:      $
��auto �6   �� 5;      $
��auto �6   �� 5<      $
��auto �6   �� 5=      $
��auto �6    5?      �� 5@      $
��auto �6   �� 5A      $��* �6   $	��150��5B      .+�5E      �� $��LastName��6   $��5q�5F   	   �� 5G      $��1��6   $��5q�5I      ��5H      �� *
LastName+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5I      �� 5K      $��	FirstName��6   $��1��5L   	   $��5q�5M   	   �� 5N      $��1��6   $��1��5O      $��5q�5Q      ��5P      �� *	FirstName+$	 TwoWay=�$
 PropertyChanged=�5Q      �� 5S      $��Home Address��6   $��2��5T   	   $��5q�5U   	   �� 5V      $��1��6   $��2��5W      $��5q�5Y      ��5X      �� *HomeAddress+$	 TwoWay=�$
 PropertyChanged=�5Y      �� 5[      $��Gender ��6   $��3��5\   	   $��5q�5]   	   �� 5^      $��1��6   $��3��5_      $��5q�5a      ��5`      �� *Gender+$	 TwoWay=�$
 PropertyChanged=�5a      �� 5c      $��	Birthday ��6   $��4��5d   	   $��5q�5e   	   �� 5f      $��1��6   $��4��5g      $��5q�5i      ��5h      �� *
Birthday+$	 TwoWay=�$
 PropertyChanged=�5i      �� 5k      $��5��5m      $��2��5n      $��5q�5o      ��5k      �� *OkButtonText+��5l      �� *	OkCommand+5o      5p      5q      5r      