#include "splashkit.h"

int main()
{
    open_window("Hello World", 800, 600);
    clear_screen(COLOR_WHITE);
    draw_text("Hello World", COLOR_BLACK, 350, 300);
    refresh_screen(60);
    delay(5000);
    return 0;
}