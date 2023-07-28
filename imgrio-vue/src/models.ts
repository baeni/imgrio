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
