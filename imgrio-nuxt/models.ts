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

export interface DropdownOption {
  key: string;
  value: string | boolean | number;
}
