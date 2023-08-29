export interface UserSettings {
  userId: string;
  imageAnimation: boolean;
  language: string;
}

export interface UserFile {
  id: string;
  author: string;
  title: string;
  type: string;
  size: number;
  url: string;
  isSelfHosted: boolean;
  dateOfCreation: string;
}
