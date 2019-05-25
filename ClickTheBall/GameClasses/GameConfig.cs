using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClickTheBall.GameClasses
{
    /// <summary>
    /// A static class for holding global data (configurations, image, sound etc).
    /// </summary>
    static class GameConfig
    {
        // Screen configs
        public static int WIDTH;
        public static int HEIGHT;
        public static bool FULLSCREEN;
        public static bool BORDERLESS;

        // UI config
        public static float SCALE;

        // Holds game point's data
        public static int POINTS; // yet not sure if it should be here ;D

        // Holds all the sprites needed for this simple game
        public static Texture2D gameTexture;

        public static SpriteFont gameFont;

        // Background and sprite colors
        public static Color bgColor;
        public static Color spColor;

        /// <summary>
        /// Loads data from an .ini (config) file.
        /// </summary>
        /// <param name="fN">The .ini file name.</param>
        public static void loadConfig(string fN)
        {
            // Initializes Parser and Data Object
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(fN);

            // Fullscreen & Borderless booleans
            string fS = data["display"]["fullscreen"];
            GameConfig.FULLSCREEN = bool.Parse(fS);
            string bL = data["display"]["borderless"];
            GameConfig.BORDERLESS = bool.Parse(bL);

            // Width and Height
            string w = data["display"]["width"];
            string h = data["display"]["height"];
            GameConfig.WIDTH = int.Parse(w);
            GameConfig.HEIGHT = int.Parse(h);

            // Scale of objects and UI
            string s = data["ui"]["scale"];
            GameConfig.SCALE = float.Parse(s);

            // Background color config
            string bgR = data["ui"]["bg_color_r"];
            string bgG = data["ui"]["bg_color_g"];
            string bgB = data["ui"]["bg_color_b"];
            GameConfig.bgColor = new Color(int.Parse(bgR), int.Parse(bgG), int.Parse(bgB));

            // Sprites color config
            string spR = data["ui"]["sp_color_r"];
            string spG = data["ui"]["sp_color_g"];
            string spB = data["ui"]["sp_color_b"];
            GameConfig.spColor = new Color(int.Parse(spR), int.Parse(spG), int.Parse(spB));

            // Print config values on console (for debugging)
            Console.WriteLine("GLOBAL CONFIGURATIONS"
                + "\n - Full Screen:" + fS
                + "\n - Borderless:" + bL
                + "\n - Screen Width:" + w
                + "\n - Screen Height:" + h
                + "\n - UI Scale:" + s
                + "\n - Background Color:RGB(" + bgR + ", " + bgG + ", " + bgB + ")"
                + "\n - UI/Sprite Color:RGB(" + spR + ", " + spG + ", " + spB + ")");
        }

        /// <summary>
        /// Loads the sprite sheet (every object's drawing is in this sheet).
        /// </summary>
        /// <param name="fN">The sprite sheet file name.</param>
        /// <param name="cM">The content manager object.</param>
        public static void loadTexture(string fN, ContentManager cM)
        {
            GameConfig.gameTexture = cM.Load<Texture2D>(fN);
        }

        /// <summary>
        /// Loads the sprite font for game's text.
        /// </summary>
        /// <param name="fN">The font's file name.</param>
        /// <param name="cM">The content manager object.</param>
        public static void loadFont(string fN, ContentManager cM)
        {
            GameConfig.gameFont = cM.Load<SpriteFont>(fN);
        }
    }
}
