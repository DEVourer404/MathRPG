using Godot;
using System;


public partial class test_battle : Node2D
{
	Random rnd = new Random();
	public bool turn = false;
	Sprite2D speech_bubble = null;
	TextEdit answer_pole = null;
	RichTextLabel q_text = null;
	double enemy_hp = 100;

	int answer = 0;
	

		public override void _Ready()
	{
		
		RichTextLabel q_text = GetNode<RichTextLabel>("GUI/question/RichTextLabel");
		enemy_hp = GetNode<ProgressBar>("GUI/EHP").Value;
		
		
		q_text.Text = addition_test(10);
		turn = true;
		
	}
	public override void _Process(double delta) 
	{
		speech_bubble = GetNode<Sprite2D>("GUI/P_Side_Text/Speechbubble");
		answer_pole = GetNode<TextEdit>("GUI/P_Side_Text/TextEdit");
		if (turn == true) 
		{
			answer_pole.Visible = true;
			answer_pole.Editable = true;
			speech_bubble.Visible = true;
		} else {
			answer_pole.Visible = false;
			speech_bubble.Visible = false;
			answer_pole.Editable = false;
		}
		
		
	}
	
	public string addition_test(int range) {
		
		int x = rnd.Next(range);
		int y = rnd.Next(range);
		answer = x + y;
		string text = (y.ToString() + " + " + x.ToString());
		return text;
	}
	
		public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("enter"))
		{
			if (answer_pole.Text.ToInt() == answer) {
				GetNode<ProgressBar>("GUI/EHP").Value -= 5;
				turn = false;
				new_turn();
			}
		}
	}

	public void new_turn()
	{
		RichTextLabel q_text = GetNode<RichTextLabel>("GUI/question/RichTextLabel");
		q_text.Text = addition_test(10);
		answer_pole.Text = "";
		turn = true;
	}

}
