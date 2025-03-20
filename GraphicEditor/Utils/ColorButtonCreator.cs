public class ColorButtonCreator
{
    private Panel colorPanel; 
    private Button penColorButton;
    private Button brushColorButton;
    private Color[] colors = {
        Color.Black, Color.White, Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple,
        Color.Brown, Color.Gray, Color.Pink, Color.Lime, Color.Cyan, Color.Magenta, Color.Gold, Color.Chocolate,
        Color.Maroon, Color.Olive, Color.Teal, Color.Navy, Color.Silver, Color.Silver, Color.Silver, Color.Silver, Color.Silver,
        Color.Silver, Color.Silver, Color.Silver, Color.Silver, Color.Silver
    };

    private Button activeColorButton;
    private int currentColorIndex = 0;

    public ColorButtonCreator(Panel colorPanel)
    {
        this.colorPanel = colorPanel;
    }

    public void CreateColorButtons()
    {
        int padding = 5;
        int startX = 10;
        int startY = 10;

        penColorButton = new Button
        {
            Size = new Size(35, 35),
            Location = new Point(startX, startY),
            BackColor = Color.Black
        };

        penColorButton.Click += (sender, e) => activeColorButton = penColorButton;
        colorPanel.Controls.Add(penColorButton);

        brushColorButton = new Button
        {
            Size = new Size(35, 35),
            Location = new Point(startX, startY + 35 + padding),
            BackColor = Color.White
        };

        brushColorButton.Click += (sender, e) => activeColorButton = brushColorButton;
        colorPanel.Controls.Add(brushColorButton);

        int btnSize = 22;
        int cols = 10;
        int x = startX + 35 + padding;
        int y = startY;

        List<Button> inactiveButtons = new List<Button>();

        for (int i = 0; i < 30; i++)
        {
            Button colorButton = new Button
            {
                Size = new Size(btnSize, btnSize),
                Location = new Point(x, y),
                BackColor = colors[i],
                Enabled = i < 20
            };

            colorButton.Click += (sender, e) =>
            {
                if (activeColorButton != null)
                {
                    activeColorButton.BackColor = colorButton.BackColor;
                }
            };

            colorPanel.Controls.Add(colorButton);

            if (i >= 20) inactiveButtons.Add(colorButton);

            x += btnSize + padding;
            if ((i + 1) % cols == 0)
            {
                x = startX + 35 + padding;
                y += btnSize + padding;
            }
        }

        Button selectColorButton = new Button
        {
            Size = new Size(45, 45),
            Location = new Point(startX + 22 * 14 + padding, startY + 15),
            BackColor = Color.White,
            BackgroundImage = Image.FromFile("rgb.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };
        selectColorButton.Click += (sender, e) => SelectCustomColor(inactiveButtons);
        colorPanel.Controls.Add(selectColorButton);
    }

    private void SelectCustomColor(List<Button> inactiveButtons)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (currentColorIndex >= inactiveButtons.Count)
                {
                    currentColorIndex = 0;
                }

                Button targetButton = inactiveButtons[currentColorIndex];

                targetButton.BackColor = colorDialog.Color;
                targetButton.Enabled = true;

                currentColorIndex++;
            }
        }
    }

    public Button PenColorButton => penColorButton;
    public Button BrushColorButton => brushColorButton;
}
