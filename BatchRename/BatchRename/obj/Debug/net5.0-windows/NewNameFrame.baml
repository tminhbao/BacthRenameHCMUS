   M S B A M L   `   `   `  ����F  BBatchRename, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BatchRenameBatchRename  5          BatchRename.NewNameFrame   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BatchRename     5        N� Title$  NewNameFrame��5	       N� 
Background
 �����.��5      ��  �� Orientation$ Vertical=�6   $
��Left=�6(   $��Center=�6C   $��20q�6`   .+�5   
   �� -   5        $��GuidName��5      $��	GUID Name��6$   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��  �6C   �� 5       � ��$ 	Underline{�68   �� 5       � ��$ 20(�61    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5      ��  � ��
 �  ��6;   5      5      5      �� 5   
   -   5        	 ��Name$	 IncNum��5      $��Incrementing numbers��6$   ��5      �� 5      " ��6   .�5      ��  � ��
 ��  �6C   �� 5        � ��$ 	Underline{�68   �� 5!       � ��$ 20(�61    5"      P� 5#       �@J�IsMouseOver$
 True��69   . �5$      ��  � ��
 �  ��6;   5%      5'      5)      �� 5*   
   -   5        $	 	IncLetter��5*      $��Incrementing letters��6'   ��5+      �� 5,      " ��6   .�5-      ��  � ��
 ��  �6C   �� 5.       � ��$ 	Underline{�68   �� 5/       � ��$ 20(�61    50      P� 51       �@J�IsMouseOver$
 True��69   . �52      ��  � ��
 �  ��6;   53      55      57      �� 58   
   -   5        $	 	Normalize��58      $��	Normalize��6'   ��59      �� 5:      " ��6   .�5;      ��  � ��
 ��  �6C   �� 5<       � ��$ 	Underline{�68   �� 5=       � ��$ 20(�61    5>      P� 5?       �@J�IsMouseOver$
 True��69   . �5@      ��  � ��
 �  ��6;   5A      5C      5E      �� 5G   
   -   5        
 ��Name$
 ReturnOldName��5G      $
��Back��6(   
������$��6q�6O   6Z   5I      5J      