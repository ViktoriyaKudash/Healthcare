   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5          DoctorApp.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:DoctorApp     5        � WindowStartupLocation$  CenterScreen=�5       � Title$ 
MainWindow��5	      $��564.796��5
      $��839.266��5      ��5      �� 5   
    �� ImageSource$ ../Resources/1414.jpg��6    �� Opacity$	 0.9Q�69   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��3��6   ��5      ��  �� ElementName$
 menu�� �� Path$ 
Background�o� 5   
   -   5         o�Name$
 menu��5      .@�5      m� $
��File��6   .@�5       m� $
��Exit��6   5!      m� 5"      $
��View��6   .@�5#      m� $��Patients��6   	 m� Command	 5$   	   �� *OpenPatientsCommand+m� 5%      $��Visits��6   	 5&   	   �� *OpenVisitsCommand+5'      m� 5(      $��Options��6   .@�5)      m� $��White Theme��6   	 5*   	   �� *WhiteThemeCommand+m� 5+      $��
Dark Theme��6   	 5,   	   �� *DarkThemeCommand+5-      5.      �� 50   
   $��1��6   $��5, 5, 30, 5q�52      
�������
���   �$	��150��55      ��51      �� *
SearchText+
 �� UpdateSourceTrigger$
 PropertyChanged=�55      �� 57   
   $��5q�58      $��22��5:      $��22��5;      $��Right=�5<      $��Center=�5=      $��Center=�5>      $��1��5?      ��59      �� *CancelSearchCommand+.��5@      �� $��../Resources/cancel.png��6   $��18��65   $��30��6A   5A      �� 5F   
   -   5         ��Name$ button��5F      $
��Left=�6!   $	��Top=�5G      $��75��5H   
   $��5q�6   $��2��5J      ��5I      �� *SearchCommand+.��5K      ��  �� Orientation$ 
Horizontal=�6   .+�5L      �� $��../Resources/search.png��6   $��0,0,5,0q�69   �� 5M      $��Search��6   5N      5O         DoctorApp.MyFrame  5Q   
   -   5          Name$ 	mainFrame��5Q      $��1��5R   	   $��3��5S        � NavigationUIVisibility$ Visible=�5T   	   5V      5W      5X      