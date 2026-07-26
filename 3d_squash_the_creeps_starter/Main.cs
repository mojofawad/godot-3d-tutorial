using Godot;

namespace SquashTheCreeps3D;

public partial class Main : Node
{
	[Export]
	public PackedScene MobScene { get; set; }
	
	public override void _Ready()
	{
		
	}
	
	public override void _Process(double delta)
	{
		
	}

	private void OnMobTimerTimeout()
	{
		var mob = MobScene.Instantiate<Mob>();

		var mobSpawnLocation = GetNode<PathFollow3D>("SpawnPath/SpawnLocation");
		mobSpawnLocation.ProgressRatio = GD.Randf();

		var playerPosition = GetNode<Player>("Player").Position;
		mob.Initialize(mobSpawnLocation.Position, playerPosition);
		
		AddChild(mob);

		mob.Squashed += GetNode<ScoreLabel>("UserInterface/ScoreLabel").OnMobSquashed;
	}

	private void OnPlayerHit()
	{
		GetNode<Timer>("MobTimer").Stop();
	}
}