   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5           DoctorApp.VisitAddEdtiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:DoctorApp     5        � Title$  VisitWindow��5	       � WindowStartupLocation$ CenterScreen=�5
      $��375.877��5      $��751.235��5         DoctorApp.DialogCloser   DialogResult 5      �� *DialogResult+��5      �� 5   
    �� ImageSource$ ../Resources/1414.jpg��6    �� Opacity$	 0.9Q�69    � 	Resources 5      ,   &DoctorApp.BooleanToVisibilityConverter    BooleanToVisibilityConverter+   %DoctorApp.ImageToImageSourceConverter  ImageToImageSourceConverter��%:   &	        &	        5      6'     5      6&   5      .��5      �  � ColumnDefinitions 5      �� 5      $
��auto �6   �� 5      $��* �6   $	��150��5   
    � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!      �� $��5q�5"      ��5!      �� *
Patients+y�5#      �� *IsInEditMode+ �� 	Converter# [  	 �� SelectedItem	 5$      �� *	Patient+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 5&      $��Patient��6   $��5q�5'      $��1��5(      .��5)      � $��1��6
   $��1��5*       5+      �� 5,      $
��auto �6   �� 5-      $
��auto �6   �� 5.      $
��auto �6   �� 5/      $
��auto �6   �� 50      $
��auto �6    52      �� 53      $
��auto �6   �� 54      $
��auto �6   �� 55      $��* �6   $	��150��56      .+�59      �� $��64��6   $��64��5:   	   $	��128��5;   	   $	��128��5<   	   $��5q�5=   	   $��5��5>   	   ��5?   	   �� *Patient.Photo+# [ �� 5A      $��LastName��6   $��1��5B   
   $��5q�5C   
   �� 5D      $��2��6    �� 
IsReadOnly . $��5q�5G      ��5F      �� *Patient.LastName+$ TwoWay=�$
 PropertyChanged=�5G      �� 5I      $��	FirstName��6   $��1��5J   
   $��1��5K   
   $��5q�5L   
   �� 5M      $��2��6   $��1��5N       . $��5q�5Q      ��5P      �� *Patient.FirstName+$ TwoWay=�$
 PropertyChanged=�5Q      �� 5S      $��Home Address��6   $��2��5T   
   $��1��5U   
   $��5q�5V   
   �� 5W      $��2��6   $��2��5X       . $��5q�5[      ��5Z      �� *Patient.HomeAddress+$ TwoWay=�$
 PropertyChanged=�5[      �� 5]      $��Gender ��6   $��3��5^   
   $��1��5_   
   $��5q�5`   
   �� 5a      $��2��6   $��3��5b       . $��5q�5e      ��5d      �� *Patient.Gender+$ TwoWay=�$
 PropertyChanged=�5e      �� 5g      $��	Birthday ��6   $��4��5h   
   $��1��5i   
   $��5q�5j   
   �� 5k      $��2��6   $��4��5l       . $��5q�5o      ��5n      �� *Patient.Birthday+$ TwoWay=�$
 PropertyChanged=�5o      5p      5q      � 5s      $��3��6	   $��1��5t       5u      �� 5v      $
��auto �6   �� 5w      $��* �6   $	��150��5x       5z      �� 5{      $
��auto �6   �� 5|      $��* �6   �� 5}      $
��auto �6   .+�5�      �� $
��Date��6   $��5q�5�   	   &   System.Windows.Controls.Calendar  5�      $��1��6      FirstDayOfWeek$ Monday=�5�         SelectedDate 5�      �� *Date+5�      �� 5�      $
��Text��6   $��1��5�   	   $��5q�5�   	   �� 5�      $��1��6   $��1��5�       �� TextWrapping$
 Wrap=�5�       �� 
AcceptsTab .  �� AcceptsReturn . $��5q�5�      ��5�      �� *Text+5�      �� 5�      $��1��6   $��2��5�      $��5q�5�      ��5�      �� *OkButtonText+��5�      �� *	OkCommand+5�      5�      5�      