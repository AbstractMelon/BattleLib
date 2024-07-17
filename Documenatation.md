# BattleLib Documentation

## Introduction

This library provides utility classes to facilitate interaction with game sessions, abilities, players, and more within Unity.

## Installation

1. Download the BattleLib library mod.
2. Import the library into your project as an assembly reference.
3. Add `using BattleLib` to the top of you code

## Usage

### `BattleUtils` Class

#### `GetGameSessionHandler()`
Retrieves the `GameSessionHandler` instance.
```csharp
BattleUtils.GetGameSessionHandler()
```

#### `GetSlimeControllers()`
Retrieves an array of `SlimeController` instances from `GameSessionHandler`.
```csharp
BattleUtils.GetSlimeControllers()
```

#### `IsGameOver` Property
Gets or sets the `gameOver` field in `GameSessionHandler`.
```csharp
BattleUtils.IsGameOver
```

#### `PrepareNextLevel()`
Invokes the private `prepareNextLevel` method in `GameSessionHandler`.
```csharp
BattleUtils.PrepareNextLevel()
```

#### `GetPlayerFromPlayerBody(PlayerBody playerBody)`
Retrieves the `Player` object associated with a `PlayerBody`.
```csharp
BattleUtils.GetPlayerFromPlayerBody(playerBody)
```

#### `GetPlayerPhysicsFromPlayerBody(PlayerBody playerBody)`
Retrieves the `PlayerPhysics` object from a `PlayerBody`.
```csharp
BattleUtils.GetPlayerPhysicsFromPlayerBody(playerBody)
```

#### `IsGameSessionActive()`
Checks if the game session is active.
```csharp
BattleUtils.IsGameSessionActive()
```

#### `GetAllPlayers()`
Retrieves a list of all active players in the game session.
```csharp
BattleUtils.GetAllPlayers()
```

#### `GetPlayerById(int playerId)`
Retrieves a specific player by their ID.
```csharp
BattleUtils.GetPlayerById(playerId)
```

#### `IsPlayerAlive(Player player)`
Checks if a player is alive.
```csharp
BattleUtils.IsPlayerAlive(player)
```

#### `EndGameSession()`
Ends the current game session.
```csharp
BattleUtils.EndGameSession()
```

#### `RespawnAllPlayers()`
Respawns all players at their spawn positions.
```csharp
BattleUtils.RespawnAllPlayers()
```

### `AbilityUtils` Class

#### `SetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator, Sprite iconSprite)`
Sets the icon sprite for a specific ability indicator.
```csharp
AbilityUtils.SetAbilityIcon(abilitySelectCharacter, indicator, iconSprite)
```

#### `ResetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator)`
Resets the icon sprite for a specific ability indicator.
```csharp
AbilityUtils.ResetAbilityIcon(abilitySelectCharacter, indicator)
```

#### `ResetAllAbilities(AbilitySelectCharacter abilitySelectCharacter)`
Resets all ability icons.
```csharp
AbilityUtils.ResetAllAbilities(abilitySelectCharacter)
```

#### `SetMultipleAbilityIcons(AbilitySelectCharacter abilitySelectCharacter, Dictionary<AbilitySelectCharacter.AbilityIndicator, Sprite> icons)`
Sets multiple ability icons from a dictionary.
```csharp
AbilityUtils.SetMultipleAbilityIcons(abilitySelectCharacter, icons)
```

#### `GetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator)`
Retrieves the current icon sprite for a specific ability indicator.
```csharp
AbilityUtils.GetAbilityIcon(abilitySelectCharacter, indicator)
```

#### `IsOnCooldown(Ability ability)`
Checks if an ability is currently on cooldown.
```csharp
AbilityUtils.IsOnCooldown(ability)
```

#### `StartCooldown(Ability ability, Fix cooldownDuration)`
Starts cooldown for an ability with a specified duration.
```csharp
AbilityUtils.StartCooldown(ability, cooldownDuration)
```

#### `ReduceCooldown(Ability ability, Fix amount)`
Reduces the cooldown of an ability.
```csharp
AbilityUtils.ReduceCooldown(ability, amount)
```

#### `ResetCooldown(Ability ability)`
Resets the cooldown of an ability.
```csharp
AbilityUtils.ResetCooldown(ability)
```

#### `LogEnterAbility(Ability ability)`
Logs the entry of an ability.
```csharp
AbilityUtils.LogEnterAbility(ability)
```

#### `LogExitAbility(Ability ability)`
Logs the exit of an ability.
```csharp
AbilityUtils.LogExitAbility(ability)
```

#### `IsAbilityCastable(Ability ability, Player player)`
Checks if an ability is castable by a player.
```csharp
AbilityUtils.IsAbilityCastable(ability, player)
```

#### `SetPlayerMaterial(Ability ability, Material material)`
Sets the material for a player associated with an ability.
```csharp
AbilityUtils.SetPlayerMaterial(ability, material)
```

#### `DoesKillPlayersOnContact(Ability ability)`
Checks if an ability kills players on contact.
```csharp
AbilityUtils.DoesKillPlayersOnContact(ability)
```

### `PlayerUtils` Class

#### `AddAbility(this Player player, GameObject ability, Sprite abilityIcon = null)`
Adds a new ability to the player's abilities list.
```csharp
player.AddAbility(ability, abilityIcon)
```

#### `RemoveAbility(this Player player, GameObject ability)`
Removes an ability from the player's abilities list.
```csharp
player.RemoveAbility(ability)
```

#### `Respawn(this Player player, Vec2 spawnPosition)`
Respawns the player at a given position.
```csharp
player.Respawn(spawnPosition)
```

#### `IncreaseScore(this Player player, int kills = 1)`
Increases the player's kill count.
```csharp
player.IncreaseScore(kills)
```

#### `ResetPlayerState(this Player player)`
Resets the player's state for a new round.
```csharp
player.ResetPlayerState()
```

#### `IsClone(this Player player)`
Checks if a player is a clone.
```csharp
player.IsClone()
```

#### `SetPosition(this Player player, Vec2 position)`
Sets the player's position based on a Vec2 position.
```csharp
player.SetPosition(position)
```

#### `IsWinning(this Player player)`
Checks if the player is currently winning.
```csharp
player.IsWinning()
```

#### `GetSteamId()`
Gets the Steam ID of the current user.
```csharp
PlayerUtils.GetSteamId()
```

### `MiscUtils` Class

#### `ResetGameState()`
Resets the game state, including player positions and loading the main menu scene.
```csharp
MiscUtils.ResetGameState()
```

#### `GetInputDevice()`
Gets the current input device.
```csharp
MiscUtils.GetInputDevice()
```

#### `UsesKeyboardAndMouse()`
Checks if the current input method is keyboard and mouse.
```csharp
MiscUtils.UsesKeyboardAndMouse()
```

#### `UsesController()`
Checks if the current input method is a controller.
```csharp
MiscUtils.UsesController()
```

### `GameUtils` Class

#### `IsSuddenDeathActive()`
Checks if sudden death mode is active.
```csharp
GameUtils.IsSuddenDeathActive()
```

#### `ActivateSuddenDeath(bool activate)`
Activates or deactivates sudden death mode.
```csharp
GameUtils.ActivateSuddenDeath(activate)
```

#### `PauseGame()`
Pauses the game.
```csharp
GameUtils.PauseGame()
```

#### `ResumeGame()`
Resumes the game.
```csharp
GameUtils.ResumeGame()
```

#### `HasGameEnded()`
Checks if the game has ended.
```csharp
GameUtils.HasGameEnded()
```

#### `EndGameImmediately()`
Ends the game immediately.
```csharp
GameUtils.EndGameImmediately()
```

### `CameraUtils` Class

#### `SmoothMove(Transform transform, Vector3 targetPosition, float smoothTime)`
Smoothly moves an object towards a target position.
```csharp
CameraUtils.SmoothMove(transform, targetPosition, smoothTime)
```

#### `ClampPosition(Vector3 position, Vector2 minBounds, Vector2 maxBounds)`
Clamps a Vector3 position within specified bounds.
```csharp
CameraUtils.ClampPosition(position, minBounds, maxBounds)
```

#### `CalculateDistance(Vector3 fromPosition, Vector3 toPosition)`
Calculates the distance between two Vector3 positions.
```csharp
CameraUtils.CalculateDistance(fromPosition, toPosition)
```

#### `RoundToNearestPixel(float unityUnits, float pixelToUnits)`
Rounds a float value to the nearest pixel.
```csharp
CameraUtils.RoundToNearestPixel(unityUnits, pixelToUnits)
```

#### `SmoothZoom(Camera camera, float targetSize, float smoothTime, float minSize, float maxSize)`
Smoothly adjusts the orthographic size of a Camera.
```csharp
CameraUtils.SmoothZoom(camera, targetSize, smoothTime, minSize, maxSize)
```

#### `GetAveragePosition(List<Vector3> positions)`
Gets the average position of a list of Vector3 positions.
```csharp
CameraUtils.GetAveragePosition(positions)
```
