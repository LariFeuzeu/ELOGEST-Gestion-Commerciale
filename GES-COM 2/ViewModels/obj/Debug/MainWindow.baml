   M S B A M L   `   `   `  ����D  @GES-COM 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GES_COM_2	GES_COM_2  5   	   ;"clr-namespace:GES_COM_2.ViewModelsGES_COM_2.ViewModels  5   	       GES_COM_2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GES_COM_2     5   	   1vm"clr-namespace:GES_COM_2.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��720��5
   	   $
��1080��5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � DataContext 5      !  GES_COM_2.ViewModels.MainVM  5   
    � 	Resources 5         RoundButtonStyle �� 
TargetType �� Property �� Value��%�  &	        '�� N    �� 5   
   " ��6)   .�5      ��  � ��$ 10q�6'   �� 5       � ��$ 60��6'   �� 5       � ��$ 60��6&   �� 5       � �� �#3d348b6+   �� 5       � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5       ��  � ��
 ���� 5"      5#      5%      .��5&      �� 
�������	 �� CornerRadius$	 25��5'      ._�5(   
   � 
 � RowDefinitions
 5*      �� 5+      $��50 �6    �� 5,      $��* �6     � ColumnDefinitions 5.      �� 5/      $	��228 �6#   �� 50      $��* �6#   .+�54      ��  �� Orientation$ Vertical=�6   $��0��55      $��1��56      $��
8,10,10,10q�57      .+�59      �� -   5         � Cursor$
 Hand��5:      #��[  5;      $��
0,10,10,10q�5<      $
��Auto��6-   $��54��6:   ��59      �� *ArticlesCommand+.��5=      �� $��Articles��6    $��Center=�5>       
�������$
��Bold"�5@      $��Center=�5A      $��20(�5B      5C      �� 5E      $
 Hand��6   #��[  5G      $��
0,10,10,10q�5H      $
��Auto��6.   $��54��6;   ��5F      �� *ClientsCommand+.��5I      �� $��Clients��6    
�������$
��Bold"�5K      $��Center=�5L      $��20(�5M      $��68��6-   5O      �� 5P      $
 Hand��6   #��[  5R      $��
0,10,10,10q�5S      $
��Auto��6-   $��54��6:   ��5Q      �� *FournisseursCommand+.��5T      �� $��Fournisseurs��6    
�������$
��Bold"�5V   $   $��Center=�5W      64   5X      �� 5Y      $
 Hand��6   #��[  5[      $��
0,10,10,10q�5\      $
��Auto��6/   $��54��6<   ��5Z      �� *ApprovisionnementsCommand+.��5]      �� $��Approvisionnement��6    
�������$
��Bold"�5_      $��Center=�5`      5a      5b      �� 5c      $
 Hand��6   #��[  5e      $��
0,10,10,10q�5f      $
��Auto��6(   $��54��65    J� RenderTransformOrigin$ 0.671,1.512&�6A   ��5d      �� *FacturationCommand+.��5g      �� $��Facturation��6    
�������$
��Bold"�5i      $��Center=�5j      $��20(�5k      5l      �� 5m      $
 Hand��6   #��[  5o      $��
0,10,10,10q�5p      $
��Auto��6(   $��54��5q      $ 0.671,1.512&�5r      ��5n      �� *UtilisateursCommand+.��5s      �� $��Utilisateur��6    
�������$
��Bold"�5u      $��Center=�5v      $��20(�5w      5x      5y      �� 5{      -   5         ��Name$ Pages��5{      $��1��5}      $��1��5~      ��5|      �� *CurrentView+5�      �� 5�      $��0��6   $��1��6&   $��Right=�5�      $ 
Horizontal=�6,   .+�5�      �� -   5        $��50��5�      $��Right=�5�      $
 Hand��5�      $��50��5�      ._�5�      �� $a��[C:\Users\FEUZEU\Documents\Visual Studio 2015\Projects\GES-COM 2\GES-COM 2\Assets\179396.png��6   $��0,10,0,0q�6�   5�      �� 5�      -   5        $��50��5�      $��Right=�5�      $
 Hand��5�      $��0,10,0,0q�6'   ._�5�      �� $b��\C:\Users\FEUZEU\Documents\Visual Studio 2015\Projects\GES-COM 2\GES-COM 2\Assets\5436332.png��6   5�      �� 5�      -   5        $��50��5�      $��Right=�5�      $
 Hand��5�      $��50��6'   $	 0,25,0,0��5�      ._�5�      �� $c��]C:\Users\FEUZEU\Documents\Visual Studio 2015\Projects\GES-COM 2\GES-COM 2\Assets\10693585.png��6   $��0,10,0,0q�6�   5�      5�      5�      5�      5�      