ADDIN_BUILD = $(top_builddir)/build
ASSEMBLY = $(ADDIN_BUILD)/MonoDevelop.ValaBinding.dll

REFS =  \
	$(GLIB_SHARP_LIBS) \
	$(GTK_SHARP_LIBS) \
	$(MONO_ADDINS_LIBS) \
	$(MONODEVELOP_CORE_ADDINS_LIBS) \
	$(MONODEVELOP_LIBS) \
	-r:Mono.Posix \
	-r:System \
	-r:System.Xml
	

FILES =  \
	AssemblyInfo.cs \
	Compiler/ICompiler.cs \
	Compiler/ValaCompiler.cs \
	gtk-gui/generated.cs \
	gtk-gui/MonoDevelop.ValaBinding.AddLibraryDialog.cs \
	gtk-gui/MonoDevelop.ValaBinding.AddPathDialog.cs \
	gtk-gui/MonoDevelop.ValaBinding.CodeGenerationPanel.cs \
	gtk-gui/MonoDevelop.ValaBinding.EditPackagesDialog.cs \
	gtk-gui/MonoDevelop.ValaBinding.GeneralOptionsPanel.cs \
	gtk-gui/MonoDevelop.ValaBinding.OutputOptionsPanel.cs \
	gtk-gui/MonoDevelop.ValaBinding.PackageDetails.cs \
	Gui/AddLibraryDialog.cs \
	Gui/AddPathDialog.cs \
	Gui/CodeGenerationPanel.cs \
	Gui/DataProvider.cs \
	Gui/EditPackagesDialog.cs \
	Gui/GeneralOptionsPanel.cs \
	Gui/OutputOptionsPanel.cs \
	Gui/PackageDetails.cs \
	Gui/ValaTextEditorExtension.cs \
	Navigation/ClassPadEventArgs.cs \
	Navigation/LanguageItemCommandHandler.cs \
	Navigation/LanguageItemEventArgs.cs \
	Navigation/LanguageItemNodeBuilder.cs \
	Navigation/ProjectNodeBuilderExtension.cs \
	Parser/Afrodite.cs \
	Parser/ProjectInformation.cs \
	Parser/ProjectInformationManager.cs \
	Parser/ValaDocumentParser.cs \
	Project/MakefileHandler.cs \
	Project/ProjectPackage.cs \
	Project/ProjectPackageCollection.cs \
	Project/ProjectPackageEventArgs.cs \
	Project/ValaCompilationParameters.cs \
	Project/ValaProject.cs \
	Project/ValaProjectBinding.cs \
	Project/ValaProjectConfiguration.cs \
	Project/ValaProjectServiceExtension.cs \
	ProjectPad/ProjectNodeExtension.cs \
	ProjectPad/ProjectPackageNodeBuilder.cs \
	ProjectPad/ProjectPackagesFolderNodeBuilder.cs \
	ProjectPad/ProjectReferencesExtension.cs \
	ValaLanguageBinding.cs

RES =  \
	gtk-gui/gui.stetic \
	gtk-gui/objects.xml \
	icons/Icons.16x16.PrivateUnion \
	icons/Icons.16x16.ProjectReference \
	icons/Icons.16x16.ProtectedUnion \
	icons/Icons.16x16.Union \
	icons/text-x-vala.16x16.png \
	icons/text-x-vala.24x24.png \
	icons/text-x-vala.32x32.png \
	icons/text-x-vala.48x48.png \
	icons/vala-icon-32.png \
	templates/ConsoleValaProject.xpt.xml \
	templates/EmptyValaProject.xpt.xml \
	templates/EmptyValaSourceFile.xft.xml \
	templates/SharedLibraryValaProject.xpt.xml \
	templates/ValaTestFixture.xpt.xml \
	templates/Makefile.am.template \
	templates/Makefile.template \
	ValaBinding.addin.xml

all: $(ASSEMBLY)

LOCAL_PKGCONFIG=PKG_CONFIG_PATH=../../local-config:$$PKG_CONFIG_PATH

$(ASSEMBLY): $(build_sources) $(build_resources)
	mkdir -p $(ADDIN_BUILD)
	$(LOCAL_PKGCONFIG) $(CSC) $(CSC_FLAGS) -debug -out:$@ -target:library $(REFS) \
		$(build_resources:%=/resource:%) $(build_sources)

valabindinglibdir = $(prefix)/lib/monodevelop/AddIns/BackendBindings
valabindinglib_DATA = $(ASSEMBLY)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb

EXTRA_DIST = $(FILES) $(RES)

# include $(top_srcdir)/Makefile.include

build_sources = $(addprefix $(srcdir)/, $(FILES)) $(GENERATED_FILES)
build_resources = $(addprefix $(srcdir)/, $(RES))
build_test_sources = $(addprefix $(srcdir)/, $(TESTFILES)) $(GENERATED_FILES)

