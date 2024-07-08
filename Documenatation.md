# BattleLib Documentation

## Introduction

This library provides utility classes to facilitate interaction with game sessions, abilities, players, and more within Unity.

## Installation

1. Download the BattleLib library mod.
2. Import the library into your project as an assembly reference.
3. Add `using BattleLib` to the top of you code

## Usage

### GameSessionHandler Utilities

#### GetGameSessionHandler

Returns the instance of the `GameSessionHandler` if it exists.

```csharp
GameSessionHandler gameSessionHandler = BattleUtils.GetGameSessionHandler();
```

#### IsGameOver

Gets or sets the game over state of the `GameSessionHandler`.

```csharp
bool gameOver = BattleUtils.IsGameOver;
BattleUtils.IsGameOver = true;
```

#### PrepareNextLevel

Invokes the private `prepareNextLevel` method in `GameSessionHandler`.

```csharp
BattleUtils.PrepareNextLevel();
```

### AbilityUtils

#### SetAbilityIcon

Sets the icon sprite for a specified ability indicator in `AbilitySelectCharacter`.

```csharp
AbilityUtils.SetAbilityIcon(abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator.X, iconSprite);
```

#### ResetAbilityIcon

Resets the icon sprite for a specified ability indicator in `AbilitySelectCharacter`.

```csharp
AbilityUtils.ResetAbilityIcon(abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator.X);
```

#### ResetAllAbilities

Resets all ability icons in `AbilitySelectCharacter`.

```csharp
AbilityUtils.ResetAllAbilities(abilitySelectCharacter);
```

#### SetMultipleAbilityIcons

Sets multiple ability icons in `AbilitySelectCharacter` using a dictionary.

```csharp
Dictionary<AbilitySelectCharacter.AbilityIndicator, Sprite> icons = new Dictionary<AbilitySelectCharacter.AbilityIndicator, Sprite>();
// Add entries to icons dictionary
AbilityUtils.SetMultipleAbilityIcons(abilitySelectCharacter, icons);
```

#### IsOnCooldown

Checks if an ability is currently on cooldown.

```csharp
bool onCooldown = AbilityUtils.IsOnCooldown(ability);
```

#### StartCooldown

Starts the cooldown for an ability with a specified duration.

```csharp
AbilityUtils.StartCooldown(ability, cooldownDuration);
```

#### ReduceCooldown

Reduces the cooldown of an ability by a specified amount.

```csharp
AbilityUtils.ReduceCooldown(ability, amount);
```

#### ResetCooldown

Resets the cooldown of an ability.

```csharp
AbilityUtils.ResetCooldown(ability);
```

#### LogEnterAbility

Logs the entry of an ability, including player ID and timestamp.

```csharp
AbilityUtils.LogEnterAbility(ability);
```

#### LogExitAbility

Logs the exit of an ability, including player ID and timestamp.

```csharp
AbilityUtils.LogExitAbility(ability);
```

#### IsAbilityCastable

Checks if an ability is castable by a specific player

```csharp
bool castable = AbilityUtils.IsAbilityCastable(ability, player);
```

#### SetPlayerMaterial

Sets the material for the player associated with the ability.

```csharp
AbilityUtils.SetPlayerMaterial(ability, material);
```

#### DoesKillPlayersOnContact

Checks if the ability kills players on contact.

```csharp
bool killsPlayers = AbilityUtils.DoesKillPlayersOnContact(ability);
```

### PlayerUtils

#### AddAbility

Adds a new ability to a player's abilities list.

```csharp
PlayerUtilsAddAbility(ability, abilityIcon);
```

#### RemoveAbility

Removes an ability from a player's abilities list.

```csharp
PlayerUtilsRemoveAbility(ability);
```

#### Respawn

Respawns the player at a specified position.

```csharp
PlayerUtilsRespawn(spawnPosition);
```

#### IncreaseScore

Increases the player's kill count.

```csharp
PlayerUtilsIncreaseScore();
```

#### ResetPlayerState

Resets the player's state for a new round.

```csharp
PlayerUtilsResetPlayerState();
```

## Conclusion

These utilities provide convenient methods to interact with game elements such as abilities, players, and game session handling in your Unity project using the BattleLib Unity library mod.
