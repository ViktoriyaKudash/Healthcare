   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5          DoctorApp.PatientsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DoctorApp     5        � DataContext  5
      !   DoctorApp.PatientsViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��3��5         AutoGenerateColumns .  ��5      �� *
Patients+ �� SelectedItem 5      �� *SelectedPatient+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	FirstName��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 90 5    
   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   
   ��  �� Path$ 	FirstName�5    
     5!      $	 LastName��6%   $
 90 5#   
    5"   
   �� $ LastName�5#   
     5$      $	 Birthday��6%   $
 90 5&   
    5%   
   �� $ Birthday�5&   
     5'      $	 Gender��6%   $
 90 5)   
    5(   
   �� $ Gender�5)   
     5*      $	 HomeAddress��6%   $
 * 5,   
    5+   
   �� $ HomeAddress�5,   
   5.      �� 50      $��1��6   $	��Top=�52      $��5q�53      $��35��54      $��35��55      ��51      �� *AddPatientCommand+.��56      ��  �� Orientation$ Vertical=�6   .+�57      �� $	��Add��6   F� 58         AddIcon#��[  6   $��1��59      
���   �$��14��5;      $��14��5<       �� Stretch$ Uniform=�5=      5>      5?      �� 5A      $��1��6   $��1��5C      $	��Top=�5D      $��5q�5E      $��35��5F      $��35��5G      ��5B      �� *EditPatientCommand+.��5H      �� $ Vertical=�6   .+�5I      �� $
��Edit��6   �� 5J      $��../Resources/edit.png��6   $��0,0,5,0q�67   $��12��6H   $��21��6T   5K      5L      5M      5N      