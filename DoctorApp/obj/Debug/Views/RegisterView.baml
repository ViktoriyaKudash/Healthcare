   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5          DoctorApp.RegisterView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:DoctorApp     5        � WindowStartupLocation$  CenterScreen=�5       � Title$. (Регистрация в системе��5	      $��213.47��5      $��323.426��5         DoctorApp.DialogCloser   DialogResult 5
      �� *DialogResult+��5      �� 5   
    �� ImageSource$ ../Resources/1414.jpg��6    �� Opacity$	 0.9Q�69   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��5       5      �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6     5%      �� 5&      $
��auto �6#   �� 5'      $��* �6#   .+�5*      �� $%��Имя пользователя��6   $��5q�5+   	   �� 5,      $��1��6   $��5q�5/      ��5-      �� *Login+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5/      �� 51      $��Пароль ��6   $��1��52   	   $��5q�53   	   �� 54      $.��(Подтверждение пароля ��6   $��2��55   	   $��5q�56   	   �� 58      $��1��6   $��1��59      $��5q�5:      ��5;      �� *
Password+$ TwoWay=�$ PropertyChanged=��� 5>      $��1��6   $��2��5?      $��5q�5@      ��5A      �� *ConfirmPassword+$ TwoWay=�$ PropertyChanged=��� 5C      $��0��6   $��2��5D      $��3��5E      $��75,10q�5F      $��25��5G      $*��$Зарегистрироваться��5I      ��5H      �� *RegisterCommand+5I      �� 5J      $��G��6   $��1��5K      $
��Left=�5L      $��6.333,22,0,0q�5M      $��1��5N      $	��Top=�5O      $	��109��5P      $��11��5Q      	 J� RenderTransformOrigin$	 0.5,0.5&�5R      $��2��5S      z�5T      V� 5U      .~�5V      �� 
 �� ScaleY$
 -1Q�6)   �� 5W      �� 5X      T� 5Y      5Z      5\      5^      5`      5b      