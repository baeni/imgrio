export interface UserFile {
  id: string;
  title: string;
  type: string;
  size: number;
  uploadedAt: string;
  uploadedBy: string;
  url: string;
  isSelfHosted: boolean;
}
