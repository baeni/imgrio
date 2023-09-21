export interface UserSetting {
  id: string;
  userId: string;
  key: string;
  value: string;
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

export interface UserFilesInfo {
  count: number;
  countToday: number;
}
