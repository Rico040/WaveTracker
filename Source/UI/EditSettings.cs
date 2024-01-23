﻿using Microsoft.Xna.Framework;
using WaveTracker.Tracker;

namespace WaveTracker.UI {
    public class EditSettings : Panel
    {
        NumberBox octave;
        NumberBox step;
        Toggle instrumentMask;
        NumberBox highlightPrimary;
        NumberBox highlightSecondary;
        public void Initialize()
        {
            octave = new NumberBox("Octave", 5, 24, 80, 40, this);
            octave.bUp.SetTooltip("", "Increase current octave - ]");
            octave.bDown.SetTooltip("", "Decrease current octave - [");
            step = new NumberBox("Step", 5, 39, 80, 40, this);
            step.bUp.SetTooltip("", "Increase step size - Ctrl+]");
            step.bDown.SetTooltip("", "Decrease step size - Ctrl+[");
            instrumentMask = new Toggle("Instrument Mask", 5, 61, this);
            instrumentMask.SetTooltip("", "Bypass auto-placement of instrument column when inputting notes");
            highlightPrimary = new NumberBox("Primary", 100, 24, 88, 40, this);
            highlightSecondary = new NumberBox("Secondary", 100, 39, 88, 40, this);
            octave.SetValueLimits(0, 9);
            step.SetValueLimits(0, 256);
            highlightPrimary.SetValueLimits(1, 256);
            highlightSecondary.SetValueLimits(1, 256);

            InitializePanel("Edit Settings", 312, 18, 194, 84);

        }

        public void Update()
        {
            octave.Update();
            step.Update();
            highlightPrimary.Update();
            highlightSecondary.Update();
            if (octave.ValueWasChanged)
                FrameEditor.currentOctave = octave.Value;
            else
                octave.Value = FrameEditor.currentOctave;

            if (step.ValueWasChanged)
                FrameEditor.step = step.Value;
            else
                step.Value = FrameEditor.step;

            if (highlightPrimary.ValueWasChanged)
                Song.currentSong.rowHighlight1 = highlightPrimary.Value;
            else
                highlightPrimary.Value = Song.currentSong.rowHighlight1;

            if (highlightSecondary.ValueWasChanged)
                Song.currentSong.rowHighlight2 = highlightSecondary.Value;
            else
                highlightSecondary.Value = Song.currentSong.rowHighlight2;

            instrumentMask.Update();
            FrameEditor.instrumentMask = instrumentMask.Value;
        }

        public void Draw()
        {
            DrawPanel();
            octave.Draw();
            step.Draw();
            highlightPrimary.Draw();
            highlightSecondary.Draw();
            instrumentMask.Draw();
            DrawRect(93, 14, 1, 63, new Color(163, 167, 194));
            Write("Note Input", 5, 15, new Color(163, 167, 194));
            Write("Row Highlight", 100, 15, new Color(163, 167, 194));

        }
    }
}