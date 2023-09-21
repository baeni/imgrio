import { library, config } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { far } from "@fortawesome/free-regular-svg-icons";
import { fas } from "@fortawesome/free-solid-svg-icons";

config.autoAddCss = false;

library.add(far, fas);

export default defineNuxtPlugin((nuxtApp) => {
    nuxtApp.vueApp.component("FaIcon", FontAwesomeIcon);
});
