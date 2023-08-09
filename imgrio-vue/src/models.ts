export interface UserDetails {
  '@odata.context': string;
  businessPhones: Array<string>;
  displayName: string;
  givenName: string;
  jobTitle: string;
  mail: string;
  mobilePhone: string;
  officeLocation: string;
  preferredLanguage: string;
  surname: string;
  userPrincipalName: string;
  id: string;
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

export interface DropdownOption {
  key: string;
  value: string | boolean | number;
}
