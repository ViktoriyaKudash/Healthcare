   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5          DoctorApp.VisitsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DoctorApp     5        � DataContext  5         DoctorApp.VisitsViewModel  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5      &   System.Windows.Controls.DataGrid     
IsReadOnly . $��3��5         AutoGenerateColumns .  ��5      �� *Visits+ �� SelectedItem 5      �� *SelectedVisit+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Date��6   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 90 5!   
   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5    
   ��  �� Path$
 Date�5!   
     5"      $	 	FirstName��6   $
 90 5$   
    5#   
   �� $ Patient.FirstName�5$   
     5%      $	 LastName��6   $
 90 5'   
    5&   
   �� $ Patient.LastName�5'   
     5(      $
	 Text��6   $
 * 5*       5)      �� $
 Text�5*      5,      �� 5.      $��1��6   $	��Add��50      $	��Top=�51      $��5q�52      $��35��53      $��35��54      ��5/      �� *AddVisitCommand+54      �� 56      $��1��6   $
��Edit��58      $��1��59      $	��Top=�5:      $��5q�5;      $��35��5<      $��35��5=      ��57      �� *EditVisitCommand+5=      5>      5?      