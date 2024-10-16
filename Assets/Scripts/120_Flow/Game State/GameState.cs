public enum GameState
{
    // Title Menu States
    TitleMenu_Top,
    TitleMenu_Config,
    TitleMenu_Load,
    TitleMenu_Exit,

    // Main Menu States
    MainMenu_Start,
    MainMenu_Options,
    MainMenu_Exit,

    // Field States
    Field_Exploration,
    Field_Event,
    Field_Shop,
    Field_Quest,
    Field_Treasure,
    Field_Travel,
    Field_Camp,
    Field_Save,

    // Battle States
    Battle_Command,
    Battle_Turn,
    Battle_Action,
    Battle_EnemyTurn,
    Battle_End,
    Battle_Victory,
    Battle_Defeat,
    Battle_ItemSelection,
    Battle_SkillSelection,

    // Inventory States
    Inventory_View,
    Inventory_UseItem,
    Inventory_Equip,
    Inventory_Store,
    Inventory_Manage,

    // Character Status States
    Character_Status,
    Character_LevelUp,
    Character_Ability,
    Character_Skills,

    // Cutscene States
    Cutscene_Intro,
    Cutscene_Ending,
    Cutscene_Event,

    // Options Menu States
    Options_Audio,
    Options_Display,
    Options_Controls,
    Options_Save,

    // Loading States
    Loading_Saving,
    Loading_Loading,
    Loading_Failed,

    // Game Over States
    GameOver_Continue,
    GameOver_Exit,

    // Tutorial States
    Tutorial_Basics,
    Tutorial_Advanced,

    // Miscellaneous States
    Misc_Pause,
    Misc_SplashScreen,
    Misc_Settings,
    Misc_Networking,

    // Input Mode States
    InputMode_Standard,
    InputMode_Advanced,

    // Additional Gameplay States (customize as needed)
    Gameplay_AchievementUnlocked,
    Gameplay_EventTriggered,
    Gameplay_CutsceneTriggered,
    Gameplay_QuestCompleted,

    // Exploration Sub-States
    Exploration_EnteringBuilding,
    Exploration_LeavingBuilding,
    Exploration_TalkingToNPC,

    // Combat Sub-States
    Combat_ChoosingTarget,
    Combat_UsingSpecialMove,

    // Interaction States
    Interaction_UsingObject,
    Interaction_TalkingToCharacter,

    // Saving States
    Saving_AutoSave,
    Saving_ManualSave,

    // Other States (Add as necessary)
    // You can fill in more unique or specific game states here to reach the total of 120.
    Custom_State_01,
    Custom_State_02,
    Custom_State_03,
    Custom_State_04,
    Custom_State_05,
    Custom_State_06,
    Custom_State_07,
    Custom_State_08,
    Custom_State_09,
    Custom_State_10,
}
