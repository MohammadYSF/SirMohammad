CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here:
    config.contentsCss = 'font.css';
    //the next line add the new font to the combobox in CKEditor
    //config.font_names = '<Cutsom Font Name>/<YourFontName>;' + config.font_names;
    config.font_names = 'Vazir-Regullar/Vazir;' + config.font_names;
};