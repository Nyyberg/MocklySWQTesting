import { CircleDot, Braces, Settings, SidebarIcon } from "lucide-react"
import {
    Sidebar,
    SidebarContent,
    SidebarFooter,
    SidebarGroup,
    SidebarGroupContent,
    SidebarHeader,
    SidebarMenu,
    SidebarMenuButton,
    SidebarMenuItem,
  } from "@/components/ui/sidebar"
  
  // Menu items.
const items = [
    {
      title: "Endpoints",
      url: "Endpoints",
      icon: CircleDot,
    },
    {
      title: "Data",
      url: "Data",
      icon: Braces,
    },
    {
      title: "Settings",
      url: "Settings",
      icon: Settings,
    },
]

  export function AppSidebar() {
    return (
      <Sidebar collapsible="icon">
        <SidebarHeader>
          <img src="/src/assets/logo_color2_with_name.png" alt="logo" className="w-20" />
        </SidebarHeader>
        <SidebarContent>
          <SidebarGroup />
          <SidebarGroupContent>
            <SidebarMenu>
                {items.map((item) => (
                    <SidebarMenuItem key={item.title}>
                        <SidebarMenuButton asChild>
                        <a href={item.url}>
                            <item.icon />
                            <span>{item.title}</span>
                        </a>
                        </SidebarMenuButton>
                    </SidebarMenuItem>
                ))}
            </SidebarMenu>
          </SidebarGroupContent>
          <SidebarGroup />
        </SidebarContent>
        <SidebarFooter />
      </Sidebar>
    )
  }
  