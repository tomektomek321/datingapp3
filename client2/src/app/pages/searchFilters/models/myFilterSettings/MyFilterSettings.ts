export interface MyFilterSettingsRs {
  userHobbies: any;
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
