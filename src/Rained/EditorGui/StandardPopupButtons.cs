using ImGuiNET;
using System.Numerics;
namespace Rained.EditorGui;

enum PopupButtonList
{
    OK,
    OKCancel,
    YesNo
};

static class StandardPopupButtons
{
    public static Vector2 ButtonSize { get => new Vector2(ImGui.GetTextLineHeight() * 6f, 0f); }

    public static bool Show(PopupButtonList list, out int buttonPressed)
    {
        var size = ButtonSize;
        bool pressed = false;
        buttonPressed = -1;

        switch (list)
        {
            case PopupButtonList.OK:
                if (ImGui.Button(I18n.T("OK"), size) || EditorWindow.IsKeyPressed(ImGuiKey.Space) || EditorWindow.IsKeyPressed(ImGuiKey.Enter) || EditorWindow.IsKeyPressed(ImGuiKey.Escape))
                {
                    pressed = true;
                    buttonPressed = 0;
                }
                break;
            
            case PopupButtonList.OKCancel:
                if (ImGui.Button(I18n.T("OK"), size) || EditorWindow.IsKeyPressed(ImGuiKey.Space) || EditorWindow.IsKeyPressed(ImGuiKey.Enter))
                {
                    pressed = true;
                    buttonPressed = 0;
                }

                ImGui.SameLine();
                if (ImGui.Button(I18n.T("Cancel"), size) || EditorWindow.IsKeyPressed(ImGuiKey.Escape))
                {
                    pressed = true;
                    buttonPressed = 1;
                }

                break;
            
            case PopupButtonList.YesNo:
                if (ImGui.Button(I18n.T("Yes"), size) || EditorWindow.IsKeyPressed(ImGuiKey.Space) || EditorWindow.IsKeyPressed(ImGuiKey.Enter))
                {
                    pressed = true;
                    buttonPressed = 0;
                }

                ImGui.SameLine();
                if (ImGui.Button(I18n.T("No"), size) || EditorWindow.IsKeyPressed(ImGuiKey.Escape))
                {
                    pressed = true;
                    buttonPressed = 1;
                }

                break;
        }

        return pressed;
    }
}
