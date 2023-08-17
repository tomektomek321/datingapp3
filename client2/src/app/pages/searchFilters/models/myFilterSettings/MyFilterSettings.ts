export interface MyFilterSettingsRs {
  userHobbies: HobbyRs[];
  categoriesWithHobbies: CategoryRs[];
}

export interface CategoryRs {
  id: number;
  name: string;
  hobbies: HobbyRs[];
}

export interface HobbyRs {
  id: number;
  name: string;
}
