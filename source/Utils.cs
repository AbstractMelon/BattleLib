using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BattleLib;
using UnityEngine;
using BoplFixedMath;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Steamworks;
using UnityEngine.UIElements;

namespace BattleLib
{
    public class BattleUtils
    {
        /// <summary>
        /// Gets the GameSessionHandler
        /// </summary>
        /// <returns>the GameSessionHandler or null if it isn't instantized</returns>
        public static GameSessionHandler GetGameSessionHandler()
        {
            FieldInfo selfRefField = typeof(GameSessionHandler).GetField("selfRef", BindingFlags.Static | BindingFlags.NonPublic);
            return selfRefField.GetValue(null) as GameSessionHandler;
        }

        /// <summary>
        /// Gets the slime controllers
        /// </summary>
        /// <returns>A list of slime controllers</returns>
        public static SlimeController[] GetSlimeControllers()
        {
            FieldInfo slimeControllersField = typeof(GameSessionHandler).GetField("slimeControllers", BindingFlags.Instance | BindingFlags.NonPublic);
            return slimeControllersField.GetValue(GetGameSessionHandler()) as SlimeController[];
        }

        /// <summary>
        /// Gives access to the private field <c>gameOver</c> in <c>GameSessionHandler</c>
        /// </summary>
        public static bool IsGameOver
        {
            get
            {
                FieldInfo gameOverField = typeof(GameSessionHandler).GetField("gameOver", BindingFlags.Instance | BindingFlags.NonPublic);
                return (bool)gameOverField.GetValue(GetGameSessionHandler());
            }
            set
            {
                FieldInfo gameOverField = typeof(GameSessionHandler).GetField("gameOver", BindingFlags.Instance | BindingFlags.NonPublic);
                gameOverField.SetValue(GetGameSessionHandler(), value);
            }
        }

        /// <summary>
        /// Gives access to the private function <c>prepareNextLevel</c> in <c>GameSessionHandler</c>
        /// </summary>
        public static void PrepareNextLevel()
        {
            MethodInfo prepareNextLevelMethod = typeof(GameSessionHandler).GetMethod("prepareNextlevel", BindingFlags.Instance | BindingFlags.NonPublic);
            prepareNextLevelMethod.Invoke(GetGameSessionHandler(), null);
        }

        /// <summary>
        /// Retrieves the <c>Player</c> corresponding to a <c>PlayerBody</c>
        /// </summary>
        /// <param name="playerBody">The <c>PlayerBody</c> object</param>
        /// <returns>The corresponding <c>Player</c> object</returns>
        public static Player GetPlayerFromPlayerBody(PlayerBody playerBody)
        {
            FieldInfo type = typeof(PlayerBody).GetField("idHolder", BindingFlags.NonPublic | BindingFlags.Instance);
            IPlayerIdHolder idHolder = (IPlayerIdHolder)type.GetValue(playerBody);
            Player player = PlayerHandler.Get().GetPlayer(idHolder.GetPlayerId());
            return player;
        }

        /// <summary>
        /// Retrieves the <c>PlayerPhysics</c> corresponding to a <c>PlayerBody</c>
        /// </summary>
        /// <param name="playerBody">The <c>PlayerBody</c> object</param>
        /// <returns>The corresponding <c>PlayerPhysics</c> object</returns>
        public static PlayerPhysics GetPlayerPhysicsFromPlayerBody(PlayerBody playerBody)
        {
            FieldInfo physicsField = typeof(PlayerBody).GetField("physics", BindingFlags.NonPublic | BindingFlags.Instance);
            return physicsField.GetValue(playerBody) as PlayerPhysics;
        }

        // Utility to check if the game session is currently active
        public static bool IsGameSessionActive()
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();
            return gameSessionHandler != null && !IsGameOver;
        }

        // Utility to get all active players in the game session
        public static List<Player> GetAllPlayers()
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();
            if (gameSessionHandler != null)
            {
                return PlayerHandler.Get().PlayerList();
            }
            return new List<Player>();
        }

        // Utility to get a specific player by their ID
        public static Player GetPlayerById(int playerId)
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();

            if (gameSessionHandler != null)
            {
                return PlayerHandler.Get().PlayerList().FirstOrDefault(p => p.Id == playerId);
            }
            return null;
        }

        // Utility to check if a player is alive
        public static bool IsPlayerAlive(Player player)
        {
            return player != null && player.CauseOfDeath == CauseOfDeath.NotDeadYet;
        }

        /*
        // Utility to get the current round number
        public static int GetCurrentRoundNumber()
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();
            return gameSessionHandler?.RoundNumber ?? 0;
        }
        */

        // Utility to end the current game session
        public static void EndGameSession()
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();
            if (gameSessionHandler != null)
            {
                IsGameOver = true;
                // gameSessionHandler.EndGame();
            }
        }

        // Utility to respawn all players at their spawn positions
        public static void RespawnAllPlayers()
        {
            GameSessionHandler gameSessionHandler = GetGameSessionHandler();
            if (gameSessionHandler != null)
            {
                foreach (var player in PlayerHandler.Get().PlayerList())
                {
                    player.Respawn(player.SpawnPosition); // Assuming SpawnPosition is a property of Player
                }
            }
        }
    }
    public class AbilityUtils
    {
        /// <summary>
        /// Sets the ability icon for the specified ability indicator
        /// </summary>
        /// <param name="abilitySelectCharacter">The AbilitySelectCharacter instance</param>
        /// <param name="indicator">The ability indicator (X, Y, Z)</param>
        /// <param name="iconSprite">The icon sprite to set</param>
        public static void SetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator, Sprite iconSprite)
        {
            abilitySelectCharacter.SetAbility(indicator, iconSprite);
        }

        /// <summary>
        /// Resets the ability icon for the specified ability indicator
        /// </summary>
        /// <param name="abilitySelectCharacter">The AbilitySelectCharacter instance</param>
        /// <param name="indicator">The ability indicator (X, Y, Z)</param>
        public static void ResetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator)
        {
            abilitySelectCharacter.ResetAbility(indicator);
        }

        /// <summary>
        /// Resets all ability icons
        /// </summary>
        /// <param name="abilitySelectCharacter">The AbilitySelectCharacter instance</param>
        public static void ResetAllAbilities(AbilitySelectCharacter abilitySelectCharacter)
        {
            abilitySelectCharacter.ResetAbilites();
        }

        /// <summary>
        /// Sets multiple ability icons
        /// </summary>
        /// <param name="abilitySelectCharacter">The AbilitySelectCharacter instance</param>
        /// <param name="icons">Dictionary containing ability indicators and their corresponding icons</param>
        public static void SetMultipleAbilityIcons(AbilitySelectCharacter abilitySelectCharacter, Dictionary<AbilitySelectCharacter.AbilityIndicator, Sprite> icons)
        {
            foreach (var icon in icons)
            {
                abilitySelectCharacter.SetAbility(icon.Key, icon.Value);
            }
        }

        /// <summary>
        /// Gets the current icon for the specified ability indicator
        /// </summary>
        /// <param name="abilitySelectCharacter">The AbilitySelectCharacter instance</param>
        /// <param name="indicator">The ability indicator (X, Y, Z)</param>
        /// <returns>The current icon sprite</returns>
        public static Sprite GetAbilityIcon(AbilitySelectCharacter abilitySelectCharacter, AbilitySelectCharacter.AbilityIndicator indicator)
        {
            switch (indicator)
            {
                case AbilitySelectCharacter.AbilityIndicator.X:
                    return abilitySelectCharacter.IconX.sprite;
                case AbilitySelectCharacter.AbilityIndicator.Y:
                    return abilitySelectCharacter.IconY.sprite;
                case AbilitySelectCharacter.AbilityIndicator.Z:
                    return abilitySelectCharacter.IconZ.sprite;
                default:
                    throw new ArgumentException("Invalid ability indicator");
            }
        }

        // Utility to check if an ability is on cooldown
        public static bool IsOnCooldown(Ability ability)
        {
            return ability.GetCooldown() > Fix.Zero;
        }

        // Utility to start cooldown for an ability
        public static void StartCooldown(Ability ability, Fix cooldownDuration)
        {
            ability.Cooldown = cooldownDuration;
        }

        // Utility to reduce the cooldown of an ability
        public static void ReduceCooldown(Ability ability, Fix amount)
        {
            ability.Cooldown = (Fix)Math.Max((sbyte)(ability.GetCooldown() - amount), (sbyte)Fix.Zero);
        }

        // Utility to reset the cooldown of an ability
        public static void ResetCooldown(Ability ability)
        {
            ability.Cooldown = Fix.Zero;
        }

        // Utility to log the entry of an ability
        public static void LogEnterAbility(Ability ability)
        {
            Debug.Log($"Entering ability for player {ability.GetPlayerId()} at {DateTime.Now}");
        }

        // Utility to log the exit of an ability
        public static void LogExitAbility(Ability ability)
        {
            Debug.Log($"Exiting ability for player {ability.GetPlayerId()} at {DateTime.Now}");
        }

        // Utility to check if an ability is castable
        public static bool IsAbilityCastable(Ability ability, Player player)
        {
            return ability.IsCastable(player) && !IsOnCooldown(ability);
        }

        // Utility to set the player material
        public static void SetPlayerMaterial(Ability ability, Material material)
        {
            ability.GetPlayerMaterial().mainTexture = material.mainTexture;
        }

        // Utility to check if the ability kills players on contact
        public static bool DoesKillPlayersOnContact(Ability ability)
        {
            return ability.KillPlayersOnContact;
        }


        /*
        // Utility to get all abilities of a player
        public static List<Ability> GetAllAbilities(Player player)
        {
            return player?.Abilities ?? new List<Ability>();
        }
        */
    }
    public static class PlayerUtils
    {
        // Adds a new ability to the player's abilities list
        public static void AddAbility(this Player player, GameObject ability, Sprite abilityIcon = null)
        {
            if (player.Abilities == null)
            {
                player.Abilities = new List<GameObject>();
            }
            player.Abilities.Add(ability);

            if (abilityIcon != null)
            {
                if (player.AbilityIcons == null)
                {
                    player.AbilityIcons = new List<Sprite>();
                }
                player.AbilityIcons.Add(abilityIcon);
            }
        }

        // Removes an ability from the player's abilities list
        public static void RemoveAbility(this Player player, GameObject ability)
        {
            if (player.Abilities != null && player.Abilities.Contains(ability))
            {
                int index = player.Abilities.IndexOf(ability);
                player.Abilities.RemoveAt(index);
                if (player.AbilityIcons != null && index < player.AbilityIcons.Count)
                {
                    player.AbilityIcons.RemoveAt(index);
                }
            }
        }

        // Respawns the player at a given position
        public static void Respawn(this Player player, Vec2 spawnPosition)
        {
            player.Position = spawnPosition;
            player.playersAndClonesStillAlive = 1;
            player.WonThisRound = false;
            player.IsMostRecentWinner = false;
            // player.TimestampWhenKilled = long.MaxValue;
            player.CauseOfDeath = CauseOfDeath.NotDeadYet;
        }

        // Increases the player's kill count
        public static void IncreaseScore(this Player player, int kills = 1)
        {
            player.Kills += kills;
        }

        // Resets the player's state for a new round
        public static void ResetPlayerState(this Player player)
        {
            player.KillsAtStartOfRound = player.Kills;
            player.Deaths = 0;
            // player.GamesWon = 0;
            player.WonThisRound = false;
            player.IsMostRecentWinner = false;
            player.playersAndClonesStillAlive = 0;
            // player.TimestampWhenKilled = long.MaxValue;
            player.CauseOfDeath = CauseOfDeath.NotDeadYet;
            player.CurrentAbilities?.Clear();
            player.RespawnPositions?.Clear();
        }

        // Utility to check if a player is a clone (not the original player)
        public static bool IsClone(this Player player)
        {
            return player.IsClone();
        }

        // Utility to set the player's position based on a Vec2 position
        public static void SetPosition(this Player player, Vec2 position)
        {
            player.Position = position;
        }

        // Utility to check if the player is currently winning
        public static bool IsWinning(this Player player)
        {
            return player.IsMostRecentWinner;
        }
        public static SteamId GetSteamId()
        {
            return SteamClient.SteamId;
        }


    }

    public static class MiscUtils {
        public static void ResetGameState()
        {
            GameSessionHandler.selfRef.gameOver = false;
            GameSessionHandler.selfRef.transitionFade.gameObject.SetActive(true);

            CircleBG.TimeSpentInMenus = 0f;

            // Reset player positions and scales
            foreach (var player in PlayerHandler.Get().PlayerList())
            {
                player.Position = Vec2.zero;
                player.Scale = Fix.One;
            }

            // Load the main menu scene
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        public static InputDevice GetInputDevice()
        {
            return InputSystem.devices[0];
        }

        public static bool UsesKeyboardAndMouse()
        {
            var device = GetInputDevice();
            return device is Keyboard || device is Mouse;
        }

        public static bool UsesController()
        {
            var device = GetInputDevice();
            return device is Gamepad || device is Joystick;
        }
    }

    public static class GameUtils {
        public static bool IsSuddenDeathActive()
        {
            return GameSessionHandler.SuddenDeathInProgress;
        }
        public static void ActivateSuddenDeath(bool activate)
        {
            GameSessionHandler.SuddenDeathInProgress = activate;
        }

        public static void PauseGame()
        {
            GameSessionHandler.GameIsPaused = true;
            InputUpdater.PauseAllRumble();
            // AudioManager.Get().PauseAll();
        }

        public static void ResumeGame()
        {
            GameSessionHandler.GameIsPaused = false;
            // InputUpdater.ResumeAllRumble();
            // AudioManager.Get().ResumeAll();
        }

        // Method to check if the game has ended
        public static bool HasGameEnded()
        {
            return GameSessionHandler.selfRef != null && !GameSessionHandler.selfRef.gameInProgress;
        }

        // Method to end the game immediately
        public static void EndGameImmediately()
        {
            if (GameSessionHandler.selfRef != null && GameSessionHandler.selfRef.gameInProgress)
            {
                GameSessionHandler.selfRef.DeclareGameUndecided(PlayerHandler.Get().PlayerList());
            }
        }
    }

    public static class CameraUtils {
        /// <summary>
        /// Smoothly move an object towards a target position.
        /// </summary>
        public static void SmoothMove(Transform transform, Vector3 targetPosition, float smoothTime)
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        /// <summary>
        /// Clamp a Vector3 position within specified bounds.
        /// </summary>
        public static Vector3 ClampPosition(Vector3 position, Vector2 minBounds, Vector2 maxBounds)
        {
            position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
            position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
            return position;
        }

        /// <summary>
        /// Calculate the distance between two Vector3 positions.
        /// </summary>
        public static float CalculateDistance(Vector3 fromPosition, Vector3 toPosition)
        {
            return Vector3.Distance(fromPosition, toPosition);
        }

        /// <summary>
        /// Round a float value to the nearest pixel.
        /// </summary>
        public static float RoundToNearestPixel(float unityUnits, float pixelToUnits)
        {
            return Mathf.Round(unityUnits * pixelToUnits) * (1f / pixelToUnits);
        }

        /// <summary>
        /// Smoothly adjust the orthographic size of a Camera.
        /// </summary>
        public static void SmoothZoom(Camera camera, float targetSize, float smoothTime, float minSize, float maxSize)
        {
            camera.orthographicSize = Mathf.Clamp(
                Mathf.Lerp(camera.orthographicSize, targetSize, smoothTime * Time.deltaTime),
                minSize,
                maxSize
            );
        }

        /// <summary>
        /// Get the average position of a list of Vector3 positions.
        /// </summary>
        public static Vector3 GetAveragePosition(List<Vector3> positions)
        {
            if (positions.Count == 0)
                return Vector3.zero;

            Vector3 average = Vector3.zero;
            foreach (Vector3 pos in positions)
            {
                average += pos;
            }
            average /= positions.Count;

            return average;
        }
    }

}
