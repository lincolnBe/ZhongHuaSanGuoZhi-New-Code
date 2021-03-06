﻿namespace OptionDialogPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class OptionDialogPlugin : GameObject, IOptionDialog, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\OptionDialog\Data\";
        private string description = "选项对话框";
        private GraphicsDevice graphicsDevice;
        private OptionDialog optionDialog = new OptionDialog();
        private const string Path = @"GameComponents\OptionDialog\";
        private string pluginName = "OptionDialogPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "OptionDialogData.xml";

        public void AddOption(string Text, object obj, GameDelegates.VoidFunction optionFunciton)
        {
            this.optionDialog.AddOptionItem(Text, obj, optionFunciton);
        }

        public void Clear()
        {
            this.optionDialog.Clear();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.optionDialog.IsShowing)
            {
                this.optionDialog.Draw(spriteBatch);
            }
        }

        public void EndAddOptions()
        {
            this.optionDialog.EndAddOptions();
        }

        public void HideOptionDialog()
        {
            this.optionDialog.IsShowing = false;
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node3 = document.FirstChild.NextSibling.ChildNodes.Item(0);
            for (int i = 0; i < node3.ChildNodes.Count; i++)
            {
                Font font;
                Microsoft.Xna.Framework.Graphics.Color color;
                XmlNode node4 = node3.ChildNodes.Item(i);
                OptionStyle style = new OptionStyle {
                    Name = node4.Attributes.GetNamedItem("Name").Value
                };
                XmlNode node = node4.ChildNodes.Item(0);
                style.TitleTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\OptionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
                style.TitleWidth = int.Parse(node.Attributes.GetNamedItem("TitleWidth").Value);
                style.TitleHeight = int.Parse(node.Attributes.GetNamedItem("TitleHeight").Value);
                style.TitleMargin = int.Parse(node.Attributes.GetNamedItem("Margin").Value);
                StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
                style.TitleText = new FreeText(this.graphicsDevice, font, color);
                style.TitleText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
                style.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
                node = node4.ChildNodes.Item(1);
                style.OptionTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\OptionDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
                style.OptionSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\OptionDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
                style.ItemHeight = int.Parse(node.Attributes.GetNamedItem("ItemHeight").Value);
                style.Margin = int.Parse(node.Attributes.GetNamedItem("Margin").Value);
                node = node4.ChildNodes.Item(2);
                StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
                style.OptionTextList = new FreeTextList(this.graphicsDevice, font, color);
                style.OptionTextList.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
                this.optionDialog.Styles.Add(style.Name, style);
            }
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\OptionDialog\OptionDialogData.xml");
        }

        public void SetReturnObjectFunction(GameDelegates.ObjectFunction returnobjectFunction)
        {
            this.optionDialog.ReturnObjectFunction = returnobjectFunction;
        }

        public void SetScreen(object screen)
        {
            this.optionDialog.Initialize(screen as Screen);
        }

        public void SetStyle(string style)
        {
            this.optionDialog.SetStyle(style);
        }

        public void SetTitle(string title)
        {
            this.optionDialog.SetTitle(title);
        }

        public void ShowOptionDialog(ShowPosition showPosition)
        {
            this.optionDialog.SetDisplayOffset(showPosition);
            this.optionDialog.IsShowing = true;
        }

        public void Update(GameTime gameTime)
        {
            if (this.optionDialog.IsShowing)
            {
                this.optionDialog.Update();
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

