   M S B A M L   `   `   `  ����D  @GES-COM 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GES_COM_2.ViewsGES_COM_2.Views  5   	   !    GES_COM_2.Views.Message_Box   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:GES_COM_2.Views     5   	   
������   � AllowsTransparency  .  � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � Title$ Message_Box��5   	   $	��139��6   $	��300��6*    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius��%  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��5      .R�5      �� #��z��5      #��z��5      #��z��5      $	 10��5      ._�5      �� $��Center=�5      5      5      5      5      5      .��5       �� 
����� �$	 20��5!      ._�5"   
   � 
 � RowDefinitions
 5#      �� 5$      $��25 �6    �� 5%      $��* �6    �� 5&      $��* �6    .+�5(      �� -   5         ��Name$ labelMessage��5)      $��Message box��5(      $��1��5*      $
��Bold"�5+      $��14(�5,      $��Center=�5-      $��Center=�5.      �� 5/      -   5         ��Name$ btnOk��50      $��OK��5/      
��� ���$��2q�52       � Cursor$
 Hand��53      
�������$��14(�55      $��2��57      $��Center=�58      $��23��60   $��115,17,111,17q�6<   59      5:      5;      